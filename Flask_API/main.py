from Fitness_math import math as fmath
from flask import Flask, request, render_template
import mysql.connector
from typing import Any, Literal
from dataclasses import dataclass, asdict
import json


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


app = Flask(__name__)







@app.route("/")
def index():
    return "Welcome to the fitness tracker. if you want to use this api go to \"/api/README\"."




@app.route("/api")
@app.route("/api/help")
@app.route("/api/README")
def api():
    return render_template("api_README.html")




@app.route("/api/users", methods=["GET"])
def get_users():
    response = Response()
    try:
        database = get_database()
        cursor = database.cursor()
        cursor.execute("SELECT * FROM users")
        users: list = cursor.fetchall()
        response.data = users

        cursor.close()
    except Exception as e:
        response.status = "error"
        response.data = str(e)
    return json.dumps(asdict(response))




@app.route("/api/users", methods=["POST"])
def post_user():
    response = Response()
    try:
        database = get_database()
        cursor = database.cursor()

        request_body = request.get_json()
        params: tuple = (
            request_body["name"],
            request_body["weight_kg"],
            request_body["height_m"],
            request_body["age"],
            request_body["sex"]
        )
        cursor.execute("INSERT INTO users (name, weight_kg, height_m, age, sex) "
                       "VALUES (%s, %s, %s, %s, %s);", params)

        database.commit()
        cursor.close()
    except Exception as e:
        response.status = "error"
        response.data = str(e)
    return json.dumps(asdict(response))



@app.route("/api/users/<int:user_id>", methods=["GET"])
def get_user(user_id: int):
    response = Response()
    try:
        database = get_database()
        cursor = database.cursor(dictionary=True)
        cursor.execute("SELECT * FROM users WHERE id = %s", (user_id,))
        user_data = cursor.fetchone()
        cursor.execute("SELECT * FROM sessions WHERE user_id = %s", (user_id,))
        sessions: list = cursor.fetchall()

        imc = fmath.calc_bmi(user_data["weight_kg"], user_data["height_m"])
        user_data |= {"imc": imc}
        response.data = {"user": user_data, "sessions": sessions}

        cursor.close()
    except Exception as e:
        response.status = "error"
        response.data = str(e)
    return json.dumps(asdict(response))



@app.route("/test")
def test():
    return render_template("test.html")
app.run(debug=True)