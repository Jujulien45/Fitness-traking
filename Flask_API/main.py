from flask import Flask, render_template, send_from_directory
import os
from Flask_API.endpoints.users import users_blueprint
from Flask_API.endpoints.sessions import sessions_blueprint

app = Flask(__name__)




@app.route("/")
def index():
    return "Welcome to the fitness tracker. if you want to use this api go to \"/api/README\"."

@app.route('/favicon.ico')
def favicon():
    return send_from_directory(os.path.join(app.root_path, 'static'),
                               'favicon.ico', mimetype='image/vnd.microsoft.icon')


@app.route("/api")
@app.route("/api/help")
@app.route("/api/README")
def api():
    return render_template("api_README.html")




############################## endpoints ##################################
app.register_blueprint(users_blueprint, url_prefix="/api/users")
app.register_blueprint(sessions_blueprint, url_prefix="/api/sessions")



@app.route("/test")
def test():
    return render_template("test.html")
app.run(debug=True)