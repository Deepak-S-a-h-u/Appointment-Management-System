import axios from "axios";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

function Login() {
  const navigate = useNavigate();
  const [loginCredentials, SetLoginCredentials] = useState({});
  const ChangeHandler = (event) => {
    SetLoginCredentials({
      ...loginCredentials,
      [event.target.name]: event.target.value,
    });
    console.log(loginCredentials);
  };
  const LoginClick = () => {
    debugger;
    axios
      .post(
        "https://localhost:44338/api/RegisterUser/LoginAuthorizeUser/",
        loginCredentials
      )
      .then((d) => {
        var x = d.data;
        console.log(x);
          var token=d.data.token;
          localStorage.setItem("userToken",token);
          localStorage.setItem("User",d.data.role);

        navigate("/department");
      });
  };

  return (
    <div>
      <div class="card text-center m-5 p-7 col-sm-5 mx-auto">
        <div class="card-header">Login</div>
        <div class="card-body  mx-auto">
          <div >
            <lable>Username : </lable>
            <input
              type="text"
              name="userName"
              onChange={ChangeHandler}
              placeholder="Username"
            ></input>
          </div>
          <div>
            <br />
            <lable>Password : </lable>
            <input
              type="password"
              name="password"
              onChange={ChangeHandler}
              placeholder="Password"
            ></input>
          </div>
        </div>
        <div class="card-footer text-muted">
          <button class="btn btn-primary" onClick={LoginClick}>
            Login
          </button>
        </div>
      </div>
    </div>
  );
}

export default Login;
