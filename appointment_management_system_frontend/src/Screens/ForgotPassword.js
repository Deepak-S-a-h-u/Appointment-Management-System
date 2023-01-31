import React from "react";
import NavBar from "./NavBar";

function ForgotPassword() {
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
            <input type="email" id="typeEmail" className="form-control my-3" />
          </div>
          <a href="#" className="btn btn-primary w-100 col-6">
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
