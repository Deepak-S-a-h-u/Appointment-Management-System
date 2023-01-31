import React from "react";
import { Link } from "react-router-dom";
import NavBar from "./NavBar";

function ResetPassword() {
  return (
    <div>
      <NavBar />
      <div>
        <div className="card text-center width: 300px">
          <div className="card-header h5 text-white bg-primary">
            Password Reset
          </div>
          <div className="card-body px-5">
            <p className="card-text py-2">
              Enter your email address and we'll send you an email with
              instructions to reset your password.
            </p>
            <div className="form-outline">
              <input
                type="email"
                id="typeEmail"
                className="form-control my-3"
              />
              <label className="" for="typeEmail">
                Email
              </label>
            </div>
            <Link to="/resetPassword" class="btn btn-outline-success my-2 my-sm-0">ResetPassword</Link>

            <div className="d-flex justify-content-between mt-4">
            <Link to="/login" class="btn btn-outline-success my-2 my-sm-0">Login</Link>

            <Link to="/register" class="btn btn-outline-success my-2 my-sm-0">Register</Link>

            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ResetPassword;
