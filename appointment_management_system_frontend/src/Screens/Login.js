import axios from "axios";
import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import NavBar from "./NavBar";
import swal from "sweetalert";
import AllUsers from "./AllUsers";


function Login() {
  var token = localStorage.getItem("userToken");
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
          console.log(d.data.role)
          localStorage.setItem("Role",d.data.role);
          var email=d.data.email;
          localStorage.setItem("email",email);
          var name=d.data.name;
          localStorage.setItem("name",name);

          swal({
            title: "Welcome "+ name,
            text: "User with email id : "+email+"  logged in successfully" ,
            icon: "success",
          });


        navigate("/home");
      });
  };

  return (
    <div>
      <NavBar/>
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
        {/* <Link to="/resetPassword" class="btn btn-outline-success my-2 my-sm-0">Reset Password</Link> */}
        <Link to="/forgotPassword" class="btn btn-outline-success my-2 my-sm-0">Forget Password</Link>

      </div>
    </div>
  );
}

export default Login;
