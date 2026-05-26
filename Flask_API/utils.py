import mysql.connector
from datetime import datetime

def get_database():
    database = mysql.connector.connect(
        host="localhost",
        user="root",
        password="",
        database="tracker_fitness"
        )
    return database





def get_datetime(datetime_str: str) -> datetime:
    """Converts a formated str into a date time.

    :param datetime_str: The format is 'yyyy/mm/dd hh:mm:ss'.
    :returns: A datetime object.
    """
    return datetime.strptime(datetime_str, "%Y-%m-%d %H:%M:%S")


def get_datetime_str(_datetime: datetime) -> str:
    """Converts a datetime into a formated str.

    :param _datetime: A datetime object.
    :returns: The format is 'yyyy/mm/dd hh:mm:ss'.
    """
    return _datetime.strftime("%Y-%m-%d %H:%M:%S")