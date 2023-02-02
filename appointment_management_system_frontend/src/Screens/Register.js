import axios from "axios";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
// import ConfirmEmail from "./ConfirmEmail";
import NavBar from "./NavBar";

function Register() {
  var role = localStorage.getItem("Role");
  console.log(role);
  const navigate = useNavigate();
  const[userRole]=useState(role);


  const initRegisterForm = {
    email: "",
    userName: "",
    name: "",
    address: "",
    genderId: "",
    password: "",
    confirmPassword: "",
    role: "",
  };
  const [userRegisterForm, SetUserRegisterForm] = useState(initRegisterForm);

  const ChangeHandler = (event) => {
    SetUserRegisterForm({
      ...userRegisterForm,
      [event.target.name]: event.target.value,
    });
    console.log(userRegisterForm);
  };

  function RegisterClick() {
    debugger;
    axios
      .post(
        "https://localhost:44338/api/RegisterUser/RegisterUser/",
        userRegisterForm
      )
      .then((d) => {
        console.log(d.data);
        // <ConfirmEmail abc='data'/>
        console.log("Registered");
        // var token=d.data.token;
        // localStorage.setItem("userToken",token);
        // console.log(d.data.role)
        // localStorage.setItem("Role",d.data.role);

        navigate("/resendEmail");
      });
  }

  return (
    <div>
      <NavBar />
      <div class="row col-sm-10 mx-auto">
        <div class="card-body p-md-5 text-black">
          <h3 class="mb-5 text-uppercase">registration form</h3>

          <div class="col-12 row">
            <label class="form-label col-4" for="Name">
              Name
            </label>
            <input
              type="text"
              id="Name"
              name="name"
              onChange={ChangeHandler}
              class="form-control col-6"
            />
          </div>

          <div class="col-12 row">
            <label class="form-label col-4" for="Address">
              Address
            </label>
            <input
              type="text"
              name="address"
              id="Address"
              onChange={ChangeHandler}
              class="form-control col-6"
            />
          </div>

          <div class="d-md-flex justify-content-center align-items-center mb-4 py-2">
            <h6 class="mb-0 me-4">Gender: </h6>

            <div class="form-check form-check-inline mb-0 me-4">
              <input
                class="form-check-input"
                type="radio"
                onChange={ChangeHandler}
                name="genderId"
                id="femaleGender"
                value="2"
              />
              <label class="form-check-label" for="femaleGender">
                Female
              </label>
            </div>

            <div class="form-check form-check-inline mb-0 me-4">
              <input
                class="form-check-input"
                type="radio"
                name="genderId"
                id="maleGender"
                value="1"
                onChange={ChangeHandler}
              />
              <label class="form-check-label" for="maleGender">
                Male
              </label>
            </div>

            <div class="form-check form-check-inline mb-0">
              <input
                class="form-check-input"
                type="radio"
                onChange={ChangeHandler}
                name="genderId"
                id="otherGender"
                value="3"
              />
              <label class="form-check-label" for="otherGender">
                Other
              </label>
            </div>
          </div>

          {userRole !== "Admin_User" ? (
            <div />
          ) : (
            <div class="d-md-flex justify-content-center align-items-center mb-4 py-2">
              <div class="col-md-6 mb-4">
                <label class="form-check-label" for="otherGender">
                  Role :
                </label>
                <select class="select" name="role" onChange={ChangeHandler}>
                  <option name="role" value="">
                    Patient
                  </option>
                  <option name="role" value="Doctor_User">
                    Doctor
                  </option>
                  <option name="role" value="Reception_User">
                    Reception
                  </option>
                </select>
              </div>
            </div>
          )}

          <div class="col-12 row">
            <label class="form-label col-4" for="email">
              UserName
            </label>
            <input
              name="userName"
              // value={}
              type="text"
              onChange={ChangeHandler}
              class="form-control col-7"
            />
          </div>
          <div class="col-12 row">
            <label class="form-label col-4" for="email">
              Email ID
            </label>
            <input
              name="email"
              // value={}
              type="text"
              onChange={ChangeHandler}
              class="form-control col-7"
            />
          </div>
          <div class="col-12 row">
            <label class="form-label col-4" for="Address">
              Password
            </label>
            <input
              type="text"
              name="password"
              id="password"
              onChange={ChangeHandler}
              class="form-control col-6"
            />
          </div>
          <div class="col-12 row">
            <label class="form-label col-4" for="Address">
              Confirm Password
            </label>
            <input
              type="text"
              name="confirmPassword"
              id="Address"
              onChange={ChangeHandler}
              class="form-control col-6"
            />
          </div>

          <div class="d-md-flex justify-content-center align-items-center mb-4 py-2">
            <button
              onClick={RegisterClick}
              type="button"
              class="btn btn-warning btn-lg ms-2"
            >
              Register
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Register;
