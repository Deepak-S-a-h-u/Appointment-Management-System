import axios from "axios";
import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import NavBar from "./NavBar";

function AllUsers() {
  const [allusers, SetAllUsers] = useState();

  useEffect(() => {
    GetAllUsers();
  }, []);

  const GetAllUsers = () => {
    axios
      .get("https://localhost:44338/api/Admin")
      .then((d) => {
        SetAllUsers(d.data);
        console.log(d.data);
        console.log(d.data);
        //   SetEmployeeForm(initData);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  function RenderUsers() {
    //debugger
    let usersRow = [];
    allusers?.map((item) => {
      console.log(item)
      usersRow.push(
        <tr>
          <td>{item.name}</td>
          <td>{item.address}</td>
          <td>{item.gender.genderValue}</td>
          <td>{item.email}</td>
          <td>
          <input type="checkbox" 
          // defaultChecked={isToggled} onClick={callback} 
          />
            {/* <button
              className="btn btn-info"
            >
              Lock
            </button>
            <button
                   >
                      Unlock
                    </button> */}
          </td>
        </tr>
      );
    });
    return usersRow;
  }

  return (
    <div>
      <NavBar />
      <div className="row">
        <div className="col-12">
          <h2 className="text-primary text-left text-center">
            All User's List
          </h2>
        </div>
      </div>
      <div>
        <div>
          <table className="table bordered col-12">
            <thead>
              <tr>
                <th>Name</th>
                <th>Address</th>
                <th>gender</th>
                <th>Email</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {RenderUsers()}
              </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default AllUsers;