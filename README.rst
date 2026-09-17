Fitness traking
===============
This project aims to make an app to track fitness progress

Showcase
--------

Javascript dashboard:
.. image:: https://raw.githubusercontent.com/Jujulien45/Fitness-traking/tree/main/images/dahsboard.png
  :alt: dashboard

winforms data history:
.. image:: https://raw.githubusercontent.com/Jujulien45/Fitness-traking/tree/main/images/history.png
  :alt: history

winforms statistics.
.. image:: https://raw.githubusercontent.com/Jujulien45/Fitness-traking/tree/main/images/stats.png
  :alt: stats


API docs
--------
The `api docs are here <Flask_API/README.rst>`_


setup the flask server
----------------------

You need a python version installed to create a venv.

first step clone or fork the repo copy all the files on your machine.

To do so you need to have git and git large storage file and have run that once::

    git lfs install

Then at the root of the project.

Create the venv::

    python -m venv .env

Activate the venv::

    .env/Scripts/Activate

Install the requirements if you only need to run the server::

    pip install -r requirements.txt

Install the dev_requirements if you want to modify the project::

    pip install -r dev_requirements.txt


Mysql database
--------------

Name it Tracker_Fitness.

Install xammp if not installed and import the "tracker_fitness.sql" database file.


Run the server
--------------

Firstly you need the mysql database running with xammp and the python venv.
go to the root of the project and run::

    python -m Flask_API.main

Hooray ! You just lauched the flask server with the api.


Run the C# winforms GUI
-----------------------

Firstly lauch the server/API.

Then launch the standalone executable at "Release/GUI.exe"


Run the javascript dashboard
----------------------------

When the flask server is launched it will automatically host the dashboard at "localhost:5000/dashboard"

So just go there to run it.
