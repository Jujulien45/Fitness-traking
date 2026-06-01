from math import isclose
from Fitness_math import fmath
from Flask_API.endpoints.sessions import get_session, post_session
from Flask_API.endpoints.users import get_users, add_user
import Flask_API.fitness_types as ftypes
from random import randint
import random
import string
from datetime import datetime
from Flask_API.utils import get_datetime_str



def test_bmi_basic():
    # the right value is 24.48... not 22.86 !!!
    assert isclose(fmath.calc_bmi(75, 1.75), 24.48, abs_tol=0.01)

def test_bmi_category_normal():
    assert fmath.bmi_category(22) == fmath.normal_weight

def test_bmi_category_underweight():
    assert fmath.bmi_category(10) == fmath.under_weight

def test_bmi_category_obese_grade_2():
    assert fmath.bmi_category(30) == fmath.obese_weight

def test_calories_burned_running_30min():
    activity_id: int = -1
    _activity: fmath.Activity
    for _activity in fmath.types:
        if _activity["name"] == "running (13 km/h)":
            activity_id: int = _activity["activity_id"]

    if activity_id == -1:
        activity_met = 1
    else:
        activity_met = fmath.met_for_activity(activity_id)
    assert isclose(fmath.kCal_burned(weight_kg=70, met_per_hour=activity_met, duration_min=30), 455)

def test_met_lookup_course():
    activity_id: int = -1
    _activity: fmath.Activity
    for _activity in fmath.types:
        if _activity["name"] == "running (13 km/h)":
            activity_id: int = _activity["activity_id"]

    activity_met = fmath.met_for_activity(activity_id)
    assert activity_met == 13.0

def test_save_session_roundtrip():
    test_done = False

    add_session: ftypes.AddedSession = {
        "user_id": 1,
        "type": ''.join(random.choices(string.ascii_letters, k=10)),
        "duration_min": randint(0, 100),
        "met": randint(0, 150),
        "date": get_datetime_str(datetime.now()),
    }
    post_session(add_session.copy())
    _sessions: list[ftypes.Session] = get_session(1)
    for session in _sessions:
        del session["id"]
        del session["calories"]
        session: ftypes.AddedSession
        # print(session == add_session)

        # for key in session.keys() | add_session.keys():
        #     print(key, session.get(key), add_session.get(key), session.get(key) == add_session.get(key))
        if session == add_session:
            test_done = True
    if not test_done:
        assert False

def test_save_user_roundtrip():
    test_done = False

    added_user: ftypes.AddedUser = {
        "name": ''.join(random.choices(string.ascii_letters, k=10)),
        "weight_kg": randint(50, 100),
        "height_m": randint(140, 210),
        "age": randint(13, 60),
        "sex": random.choice(['M', 'F'])
    }
    add_user(added_user.copy())
    _users: list[ftypes.User] = get_users()
    for user in _users:
        del user["id"]
        user: ftypes.AddedUser
        if user == add_user:
            test_done = True
    if not test_done:
        assert False

test_save_user_roundtrip()

"""
def test_weekly_stats_aggregation():
def test_bmi_history_returns_chronological
def test_validate_negative_weight_rejected
"""