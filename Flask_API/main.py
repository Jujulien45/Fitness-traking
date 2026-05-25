from Fitness_math import math as fmath
from flask import Flask, request, render_template
import mysql.connector
from typing import Any, Literal, TypedDict, get_type_hints
from dataclasses import dataclass, asdict
import json
from datetime import datetime

app = Flask(__name__)
def get_database():
    database = mysql.connector.connect(
        host="localhost",
        user="root",
        password="",
        database="tracker_fitness"
        )
    return database



@dataclass
class Response:
    status: Literal["ok", "error"] = "ok"
    data: Any = None

class AddedUser(TypedDict):
    name: str
    weight_kg: float | int
    height_m: float | int
    age: int
    sex: Literal["M", "F"]

class User(AddedUser):
    id: int

class AddedSession(TypedDict):
    user_id: int
    type: str
    duration_min: int
    met: float | int
    date: datetime

class CaloriesSession(AddedSession):
    calories: float | int

class Session(CaloriesSession):
    id: int

def matches_typeddict(data: dict, td_class) -> bool:
    hints = get_type_hints(td_class)

    for key, expected_type in hints.items():
        if key not in data:
            return False

        if not isinstance(data[key], expected_type):
            return False

    return True



def get_datetime(datetime_str: str) -> datetime:
    """Converts a formated str into a date time.

    :param datetime_str: The format is 'yyyy/mm/dd hh:mm:ss'.
    :returns: A datetime object.
    """
    return datetime.strptime(datetime_str, "%Y/%m/%d %H:%M:%S")





@app.route("/")
def index():
    return "Welcome to the fitness tracker. if you want to use this api go to \"/api/README\"."





@app.route("/api")
@app.route("/api/help")
@app.route("/api/README")
def api():
    return render_template("api_README.html")




############################## endpoints ##################################
@app.route("/api/users", methods=["GET", "POST"])
def get_users():
    response = Response()
    try:
        database = get_database()
        cursor = database.cursor(dictionary=True)


        if request.method == "GET":
            cursor.execute("SELECT * FROM users")
            users: list = cursor.fetchall()
            response.data = users

        elif request.method == "POST":
            user = request.get_json()
            if not matches_typeddict(user, AddedUser):
                raise ValueError(f"Did not match the expected AddedUser format, value: {user}")
            user: AddedUser
            params: tuple = (
                user["name"],
                user["weight_kg"],
                user["height_m"],
                user["age"],
                user["sex"]
            )
            cursor.execute("INSERT INTO users (name, weight_kg, height_m, age, sex) "
                           "VALUES (%s, %s, %s, %s, %s);", params)

            database.commit()

        cursor.close()
    except Exception as e:
        response.status = "error"
        response.data = str(e)
        print(e)
    return json.dumps(asdict(response))






@app.route("/api/users/<int:user_id>", methods=["GET", "PUT"])
def get_user(user_id: int):
    response = Response()
    try:
        database = get_database()
        cursor = database.cursor(dictionary=True)

        if request.method == "GET":
            cursor.execute("SELECT * FROM users WHERE id = %s", (user_id,))
            user: dict = cursor.fetchone()
            if not matches_typeddict(user, User):
                raise ValueError(f"No user have that id: {user_id}")
            user: User

            imc = fmath.calc_bmi(user["weight_kg"], user["height_m"])
            user |= {"imc": imc}
            response.data = user

        elif request.method == "PUT":
            user: dict = request.get_json()
            if not matches_typeddict(user, User):
                raise ValueError(f"Did not match the expected User format, value: {user}")
            user: User

            params: tuple = (
                user["name"],
                user["weight_kg"],
                user["height_m"],
                user["age"],
                user["sex"],
                user["id"]
            )
            cursor.execute(
                "UPDATE users SET name = %s, weight_kg = %s, height_m = %s, age = %s, sex = %s "
                "WHERE id = %s;",
                params
            )

            database.commit()

        cursor.close()
    except Exception as e:
        response.status = "error"
        response.data = str(e)
    return json.dumps(asdict(response))





@app.route("/api/sessions", methods=["GET", "POST"])
def user_session():
    response = Response()
    try:
        database = get_database()
        cursor = database.cursor(dictionary=True)

        if request.method == "GET":
            user_id = request.args.get("user_id")
            if user_id is None:
                raise ValueError("The '/api/sessions' GET request needs a user_id as a query url parameter.")

            cursor.execute("SELECT * FROM sessions WHERE user_id = %s", (user_id,))
            sessions: list[Session] = cursor.fetchall()

            response.data = sessions


        elif request.method == "POST":
            session: dict = request.get_json()

            if session.get("date") is None:
                raise ValueError("Missing date for the session")
            session["date"] = get_datetime(session["date"])

            if matches_typeddict(session, AddedSession):
                raise ValueError(f"Did not match the expected AddedSession format, value: {session}")
            session: AddedSession

            cursor.execute(
                "SELECT weight_kg FROM users WHERE id = %s",
                (session["user_id"],)
            )
            weight_kg: int | float = cursor.fetchone()
            if weight_kg is None:
                raise ValueError(f"user_id is not an existing user id: {session["user_id"]}")

            calories: dict = {"calories": fmath.kCal_burned(
                weight_kg,
                session["met"],
                session["duration_min"]
            )}
            session |= calories
            session: CaloriesSession

            params: tuple = (
                session["user_id"],
                session["type"],
                session["duration_min"],
                session["met"],
                session["date"],
                session["calories"]
            )
            cursor.execute(
                "INSERT INTO users SET name = %s, weight_kg = %s, height_m = %s, age = %s, sex = %s "
                "WHERE id = %s;",
                params
            )

            database.commit()

        cursor.close()
    except Exception as e:
        response.status = "error"
        response.data = str(e)
    return json.dumps(asdict(response))


@app.route("/test")
def test():
    return render_template("test.html")
app.run(debug=True)