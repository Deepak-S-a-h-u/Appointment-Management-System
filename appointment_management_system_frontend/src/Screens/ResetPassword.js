import axios from "axios";
import React from "react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import NavBar from "./NavBar";

function ResetPassword() {
  const navigate = useNavigate();
  const myKeyValues=window.location.search;
  const urlParms=new URLSearchParams(myKeyValues);
const UserDetailsInit={
  userId:urlParms.get('UserId'),
  token:urlParms.get('code`'),
  password:"",
  resetPassword:""
}

  const [userDetails,SetUserDetails]=useState(UserDetailsInit);


  // const UserId=urlParms.get('UserId');
  // const Code=urlParms.get('code');
  // console.log(UserId,Code)
  // const values={UserId,Code}
// SetUserDetails(...userDetails,userId=UserID);
// SetUserDetails(...userDetails,code=Code);

const ChangeHandler=(e)=>{
  SetUserDetails({
    ...userDetails,[e.target.name]: e.target.value,
  })
  console.log(userDetails)
};

const ResetPasswordClick=()=>{
  axios
  .post(
    "https://localhost:44338/api/RegisterUser/ResetPassword",
    userDetails
  )
  .then((d) => {
    console.log(d.data);
    
    console.log("ResetPasswordCalled");

    navigate("/login");
  });
}


  return (
    <div>
      <NavBar />
      <div>
        <div className="card text-center width: 300px">
          <div className="card-header h5 text-white bg-primary">
          <h1>  {"Hii "+localStorage.getItem("name")} Reset Your Password </h1>
          </div>
          <div  className="border m-4 p-4">
            <div className="border m-2 p-2">
              <label for="password" className="col-3">
                New Password
              </label>
              <input type="text" onChange={ChangeHandler} id="password" name="password" />
            </div>
            <div className="border m-2 p-2">
              <label for="confirmPassword" className="col-3">
               Confirm New Password
              </label>
              <input type="text" onChange={ChangeHandler} id="confirmPassword" name="confirmPassword" />
            </div>
          </div>
          <button onClick={ResetPasswordClick}>Reset Password</button>
        </div>
      </div>
    </div>
  );
}

export default ResetPassword;
