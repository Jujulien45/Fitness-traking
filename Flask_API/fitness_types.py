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