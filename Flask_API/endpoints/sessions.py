from flask import Blueprint, request
from dataclasses import asdict

import Flask_API.fitness_types as ftypes
from Fitness_math import fmath
from Flask_API.utils import get_database, get_datetime, get_datetime_str


sessions_blueprint: Blueprint = Blueprint("/api/sessions", __name__)






def post_session(session: ftypes.AddedSession | None = None):
    database = get_database()
    cursor = database.cursor(dictionary=True)
    if session is None:
        session: dict = request.get_json()

        #if ftypes.matches_typeddict(session, ftypes.AddedSession):
        #    raise ValueError(f"Did not match the expected AddedSession format, value: {session}")
    session: ftypes.AddedSession

    cursor.execute(
        "SELECT weight_kg FROM users WHERE id = %s",
        (session["user_id"],)
    )
    weight_kg: int | float = cursor.fetchone()["weight_kg"]
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
        "INSERT INTO sessions SET user_id = %s, type = %s, duration_min = %s, met = %s, date = %s, calories = %s",
        params
    )

    database.commit()
    cursor.close()



def get_session(user_id: int = -1) -> list[ftypes.Session]:
    database = get_database()
    cursor = database.cursor(dictionary=True)
    if user_id == -1:
        user_id = request.args.get("user_id")
        if user_id is None:
            raise ValueError("The '/api/sessions' GET request needs a user_id as a query url parameter.")

    cursor.execute("SELECT * FROM sessions WHERE user_id = %s ORDER BY date", (user_id,))
    sessions: list[ftypes.SessionDatetime] = cursor.fetchall()
    for session in sessions:
        session["date"] = get_datetime_str(session["date"])

    sessions: list[ftypes.Session]
    cursor.close()
    return sessions



@sessions_blueprint.route("/", methods=["GET", "POST"])
def user_session():
    response = ftypes.Response()
    try:
        if request.method == "GET":
            response.data = get_session()

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
    return asdict(response)