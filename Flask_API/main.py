from Fitness_math import math as fmath
from flask import Flask, request, render_template
import mysql.connector
from typing import Any, Literal
from dataclasses import dataclass, asdict
import json

database = mysql.connector.connect(
    host="127.0.0.1",
    port=3306,
    user="root"
    )

def get_database():
    database = mysql.connector.connect(
        host="localhost",
        user="root",
        password="",
        database="tracker_fitness"
        )
    return database




app = Flask(__name__)







@app.route("/")
def index():
    cursor = database.cursor()
    cursor.close()
    return "app index"

