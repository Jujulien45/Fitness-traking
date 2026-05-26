from math import isclose
from Fitness_math import fmath
from Flask_API.endpoints.sessions import get_session, post_session
import Flask_API.fitness_types as ftypes
from random import randint
import random
import string
from datetime import datetime
from Flask_API.utils import get_datetime_str



def test_bmi_basic():
    assert isclose(fmath.calc_bmi(75, 1.75), 22.86)

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
    add_session: ftypes.AddedSession = {
        "user_id": 0,
        "type": ''.join(random.choices(string.ascii_letters, k=10)),
        "duration_min": randint(0, 100),
        "met": randint(0, 150),
        "date": get_datetime_str(datetime.now()),
    }
    post_session(add_session)
    _sessions = get_session(0)
    for session in _sessions:
        session: ftypes.AddedSession
        del session["id"]
        if session == add_session:
            assert True

    assert False

"""
def test_weekly_stats_aggregation
def test_bmi_history_returns_chronological
def test_validate_negative_weight_rejected
"""