Fitness Tracker API
===================


The endpoints are expressed without the server ip and port.

general
-------
"/": The index, it welcomes you to the API.

"/api/README": This README.

endpoints
---------
For endpoints the format of a response is always in the same format:µ

.. code-block:: json

    {
      "data": data here,
      "status": "ok"
    }

or:

.. code-block:: json

    {
      "data": error code here as a string,
      "status": "error"
    }

inner type: ftypes.Response

So error format won't be described in the following endpoints.

And only "data" format will be explained.

sessions endpoints
------------------
**/api/sessions?user_id=int (GET)**
    Gets the sessions of the user with this user_id.

    Return example:

    .. code-block:: json

        {
          "data": [
            {
              "calories": 10400.0,
              "date": "2026-05-31 13:00:00",
              "duration_min": 10.0,
              "id": 1,
              "met": 13.0,
              "type": "running (13 km/h)",
              "user_id": 1
            },
            ...
          ],
          "status": "ok"
        }

    Data type:
        list[ftypes.Session]


**/api/sessions?user_id=int (POST)**
    Adds a session to the user with this user_id.

    POST request body's format and type:

    .. code-block:: json

        {
            "user_id": int,
            "type": str,
            "duration_min": int,
            "met": float,
            "date": "YYYY-MM-DD hh:mm:ss"
        }

    Data type:
        ftypes.AddedSession

    Returns:

    .. code-block:: json

        {
          "data": None,
          "status": "ok"
        }

    Data type:
        ftypes.Response


**/api/sessions/types**
    Gets the different types name and data for all the known sessions types. There are about 100 types.

    Return example:

    .. code-block:: json

        {
          "data": [
            {
              "activity_id": 1,
              "met": 0.8999999761581421,
              "name": "sleeping"
            },
            {
              "activity_id": 2,
              "met": 1.0,
              "name": "lying awake"
            },
            ...
          ],
          "status": "ok"
        }

    Data type:
        list[fmath.Activity]



users endpoints
---------------
**/api/users (GET)**
    Gets all the users.

    Return example:

    .. code-block:: json

        {
          "data": [
            {
              "age": 17,
              "height_m": 195.0,
              "id": 1,
              "name": "Julien",
              "sex": "M" or "F",
              "weight_kg": 80.0
            },
            ...
          ],
          "status": "ok"
        }

    Data type:
        list[ftypes.User]

**/api/users (POST)**
    Adds a new user to the database.

    POST request body's format and type:

    .. code-block:: json

        {
          "age": 17,
          "height_m": 195.0,
          "name": "Julien",
          "sex": "M" or "F",
          "weight_kg": 80.0
        }

    Data type:
        ftypes.AddedUser

    Returns:

    .. code-block:: json

        {
          "data": None,
          "status": "ok"
        }

    Data type:
        ftypes.Response


**/api/users/<int:user_id> (GET)**
    Gets the user data.

   Return example:

    .. code-block:: json

        {
          "data":
            {
              "id": 1,
              "age": 17,
              "height_m": 195.0,
              "id": 1,
              "name": "Julien",
              "sex": "M" or "F",
              "weight_kg": 80.0
            }
          "status": "ok"
        }


    Data type:
        ftypes.User


**/api/users/<int:user_id> (PUT)**
    Updates the data of the user with this user_id.

    PUT request body's format and type:

    .. code-block:: json

        {
            "name": str
            "weight_kg": float
            "height_m": float
            "age": int
            "sex": "M" or "F"
        }

    Data types:
        ftypes.AddedUser or
        ftypes.User (Not recommended)

    Returns:

    .. code-block:: json

        {
          "data": None,
          "status": "ok"
        }

    Data type:
        ftypes.Response


**/api/users/<int:user_id>/stats (GET)**
    Gets the user stats.

   Return example:

    .. code-block:: json

        {
          "data": [
            {
              "count": 28,
              "total_kcal": 115300.00128173828,
              "total_min": "1169",
              "type": "running (13 km/h)"
            },
            ...
          ],
          "status": "ok"
        }

    Data type:
        ftypes.Stats


**/api/users/<int:user_id>/bmi_history (GET)**
    Gets the user bmi history.

   Return example:

    .. code-block:: json

        {
          "data": [
            {
              "bmi": 21.038789749145508,
              "date": "2026-05-31 19:41:08"
            },
            ...
          ],
          "status": "ok"
        }

    Data type:
        ftypes.Stats
