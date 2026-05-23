from Fitness_math import math as fmath
from flask import Flask
import mysql.connector

database = mysql.connector.connect(
    host="127.0.0.1",
    port=3306,
    user="root"
    )

app = Flask(__name__)

@app.route("/")
def index():
    cursor = database.cursor()
    cursor.close()
    return "app index"

