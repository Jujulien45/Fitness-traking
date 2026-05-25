from flask import Blueprint, request
from dataclasses import asdict

import Flask_API.fitness_types as ftypes
from Flask_API.utils import get_database
from Fitness_math import math as fmath

users_blueprint: Blueprint = Blueprint("api/users", __name__)







def get_users() -> list[ftypes.User]:
    database = get_database()
    cursor = database.cursor(dictionary=True)

    cursor.execute("SELECT * FROM users")
    _users: list[ftypes.User] = cursor.fetchall()

    cursor.close()
    return _users


def add_user():
    database = get_database()
    cursor = database.cursor(dictionary=True)

    _user = request.get_json()
    if not ftypes.matches_typeddict(_user, ftypes.AddedUser):
        raise ValueError(f"Did not match the expected AddedUser format, value: {_user}")
    _user: ftypes.AddedUser
    params: tuple = (
        _user["name"],
        _user["weight_kg"],
        _user["height_m"],
        _user["age"],
        _user["sex"]
    )
    cursor.execute("INSERT INTO users (name, weight_kg, height_m, age, sex) "
                   "VALUES (%s, %s, %s, %s, %s);", params)

    database.commit()
    cursor.close()


@users_blueprint.route("/", methods=["GET", "POST"])
def users():
    response = ftypes.Response()
    try:
        if request.method == "GET":
            response.data = get_users()

        elif request.method == "POST":
            add_user()

    except Exception as e:
        response.status = "error"
        response.data = str(e)

    return asdict(response)




def get_user(user_id: int) -> ftypes.User:
    database = get_database()
    cursor = database.cursor(dictionary=True)

    cursor.execute("SELECT * FROM users WHERE id = %s", (user_id,))
    _user: dict = cursor.fetchone()
    if not ftypes.matches_typeddict(_user, ftypes.User):
        raise ValueError(f"No user have that id: {user_id}")
    _user: ftypes.User

    imc = fmath.calc_bmi(_user["weight_kg"], _user["height_m"])
    _user |= {"imc": imc}

    cursor.cloase()
    return _user


def update_user(user_id: int):
    database = get_database()
    cursor = database.cursor(dictionary=True)

    _user: dict = request.get_json()
    if not ftypes.matches_typeddict(_user, ftypes.User):
        if not ftypes.matches_typeddict(_user, ftypes.AddedUser):
            raise ValueError(f"Did not match the expected User or AddedUser format, value: {_user}")
        else:
            _user: ftypes.AddedUser
    else:
        _user: ftypes.User
        if _user["id"] != user_id:
            raise ValueError("the user id in the body of the PUT request is different from the user id in the url."
                             "Consider syncing those or getting rid of the user id in the body"
                             f"user ids, request body: {_user['id']}, url: {user_id}.")

    params: tuple = (
        _user["name"],
        _user["weight_kg"],
        _user["height_m"],
        _user["age"],
        _user["sex"],
        user_id
    )
    cursor.execute(
        "UPDATE users SET name = %s, weight_kg = %s, height_m = %s, age = %s, sex = %s "
        "WHERE id = %s;",
        params
    )

    database.commit()
    cursor.close()


@users_blueprint.route("/<int:user_id>", methods=["GET", "PUT"])
def user(user_id: int):
    response = ftypes.Response()
    try:
        if request.method == "GET":
            response.data = get_user(user_id)

        elif request.method == "PUT":
            update_user(user_id)

    except Exception as e:
        response.status = "error"
        response.data = str(e)

    return asdict(response)