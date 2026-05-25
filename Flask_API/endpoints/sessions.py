from flask import Blueprint, request
from dataclasses import asdict

import Flask_API.fitness_types as ftypes
import Fitness_math.math as fmath
from Flask_API.utils import get_database, get_datetime


sessions_blueprint: Blueprint = Blueprint("/api/sessions", __name__)






def post_session():
    database = get_database()
    cursor = database.cursor(dictionary=True)
    session: dict = request.get_json()

    if session.get("date") is None:
        raise ValueError("Missing date for the session")
    session["date"] = get_datetime(session["date"])

    if ftypes.matches_typeddict(session, ftypes.AddedSession):
        raise ValueError(f"Did not match the expected AddedSession format, value: {session}")
    session: ftypes.AddedSession

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
    session: ftypes.CaloriesSession

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



def get_session() -> list[ftypes.Session]:
    database = get_database()
    cursor = database.cursor(dictionary=True)
    user_id = request.args.get("user_id")
    if user_id is None:
        raise ValueError("The '/api/sessions' GET request needs a user_id as a query url parameter.")

    cursor.execute("SELECT * FROM sessions WHERE user_id = %s", (user_id,))
    sessions: list[ftypes.Session] = cursor.fetchall()

    cursor.close()
    return sessions



@sessions_blueprint.route("/", methods=["GET", "POST"])
def user_session():
    response = ftypes.Response()
    try:
        if request.method == "GET":
            request.data = get_session()

        elif request.method == "POST":
            post_session()

    except Exception as e:
        response.status = "error"
        response.data = str(e)

    return asdict(response)




@sessions_blueprint.route("/types", methods=["GET"])
def types():
    response: ftypes.Response = ftypes.Response()
    response.data = fmath.types
    return response