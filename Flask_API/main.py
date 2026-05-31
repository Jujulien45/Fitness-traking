from flask import Flask, send_from_directory, abort
import os
from Flask_API.endpoints.users import users_blueprint
from Flask_API.endpoints.sessions import sessions_blueprint
app = Flask(__name__)




@app.route("/")
def index():
    return "Welcome to the fitness tracker. if you want to use this api go to \"/api/README.html\"."

@app.route('/favicon.ico')
def favicon():
    return send_from_directory(os.path.join(app.root_path, 'static'),
                               'favicon.ico', mimetype='image/vnd.microsoft.icon')



SPHINX_BUILD_DIR = os.path.join(os.path.dirname(__file__), "docs/_build")

@app.route("/api/")
@app.route("/api/<path:filename>")
def docs(filename = "index.html"):
    file_path = os.path.join(SPHINX_BUILD_DIR, filename)

    if os.path.isfile(file_path):
        return send_from_directory(SPHINX_BUILD_DIR, filename)

    return abort(404)



############################## endpoints ##################################
app.register_blueprint(users_blueprint, url_prefix="/api/users")
app.register_blueprint(sessions_blueprint, url_prefix="/api/sessions")



@app.route("/test")
def test():
    return render_template("test.html")
app.run(debug=True)