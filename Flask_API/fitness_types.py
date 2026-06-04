from dataclasses import dataclass
from typing import Literal, TypedDict, Any, get_type_hints
from datetime import datetime

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
    date: str

class CaloriesSession(AddedSession):
    calories: float | int

class Session(CaloriesSession):
    id: int

class SessionDatetime(TypedDict):
    id: int
    user_id: int
    type: str
    duration_min: int
    met: float | int
    date: datetime
    calories: float | int


class Stat(TypedDict):
    total_min: int
    total_kcal: float | int
    count: int
    type: str

Stats = list[Stat]


class BmiData(TypedDict):
    date: str
    bmi: float | int
    category: str


BmiHistory = list[BmiData]

def matches_typeddict(data: dict, td_class) -> bool:
    hints = get_type_hints(td_class)

    if not isinstance(data, dict):
        return False

    for key in hints:
        if key not in data:
            return False

    return True