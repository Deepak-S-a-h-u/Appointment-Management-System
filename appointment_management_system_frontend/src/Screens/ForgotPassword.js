import axios from "axios";
import React from "react";
import { useState } from "react";
import NavBar from "./NavBar";

function ForgotPassword() {
  const emailInit = { email: "" };
  const [userEmail, SetuserEmail] = useState(emailInit);
  const ChangeHandler = (event) => {
    SetuserEmail({
      ...userEmail,
      [event.target.name]: event.target.value,
    });
    console.log(userEmail);
  };
  const ForgetPasswordBtn = () => {
    axios
      .post("https://localhost:44338/api/RegisterUser/ForgotPassword", userEmail)
      .then((d) => {
        console.log("forget password",d.data);
      });
  };
  return (
    <div>
      <NavBar />
      <div className="card text-center">
        <div className="card-header h5 text-white bg-primary offset-2 col-8">
          Password Reset
        </div>
        <div className="card-body px-5">
          <p className="card-text py-2">
            Enter your email address and we'll send you an email with
            instructions to reset your password.
          </p>
          <div className="form-outline w-100 offset-3 col-6">
            <label className="form-label text-center" for="typeEmail">
              Email input
            </label>
            <input type="email" onChange={ChangeHandler} name="email" value={userEmail.email} id="typeEmail" className="form-control my-3" />
          </div>
          <a onClick={ForgetPasswordBtn} className="btn btn-primary w-100 col-6">
            Reset password
          </a>
          <div className="d-flex justify-content-between mt-4">
            <a className="" href="#">
              Login
            </a>
            <a className="" href="#">
              Register
            </a>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ForgotPassword;
