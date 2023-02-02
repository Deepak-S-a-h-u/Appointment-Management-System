import axios from "axios";
import React from "react";
import { useState } from "react";
import { Link } from "react-router-dom";

export default function ResendEmail() {
  const emailInit = { email: "" };
  const [userEmail, SetuserEmail] = useState(emailInit);
  const ChangeHandler = (event) => {
    SetuserEmail({
      ...userEmail,
      [event.target.name]: event.target.value,
    });
    console.log(userEmail);
  };
  const ResendEmailBtn = () => {
    axios
      .post("https://localhost:44338/api/RegisterUser/ResendEmail", userEmail)
      .then((d) => {
        console.log(d.data);
      });
  };
  return (
    <div className="offset-1 col-10">
      <h1>Congratulations</h1>
      <h1>We Sent you an email </h1>
      <h2>To Login you Must confirm your email first</h2>
      <br/>
      <br/>
      <div className="row col-12">
      <div className="col-5 ">
        <h3>if you did not receive any email then enter your email and click on <b>"Send Email Again"</b> button to resend email To confirm</h3>
        <label><h2>Email Address : </h2></label>
        <input type="email" onChange={ChangeHandler} name="email" value={userEmail.email}></input>
        <button className="btn btn-info" onClick={ResendEmailBtn}>
          Send Email Again
        </button>
      </div>
      <div className="col-5 offset-2">
        <h3>if You recieved the email and confirmed it then you can Login </h3>
        <h1>Click here to login</h1>
        <Link to="/login" className="btn btn-info">
          Login
        </Link>
      </div>
      </div>
    </div>
  );
}
