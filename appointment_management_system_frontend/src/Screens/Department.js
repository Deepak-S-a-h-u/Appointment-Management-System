import axios from "axios";
import React, { useEffect, useState } from "react";

function Department() {
  const [department, SetDepartment] = useState([]);
  const [departmentForm, SetDepartmentForm] = useState({});
  useEffect(() => {
    GetAllDepartments();
  },[]);
  const GetAllDepartments = () => {
    axios
      .get("https://localhost:44375/api/Department")
      .then((d) => {
        SetDepartment(d.data);
        console.log(d.data);
        console.log(d.data)
        //   SetEmployeeForm(initData);
      })
      .catch((e) => {
        console.log(e);
      });
  };
  const SaveDepartments = () => {
    axios
      .post("https://localhost:44375/api/Department/",departmentForm)
      .then(() => {
        alert("Data Saved")
        GetAllDepartments();
        //   SetEmployeeForm(initData);
      })
      .catch((e) => {
        console.log(e);
      });
  };
  function RenderDepartments()
  {
    // debugger
    let departmentRow = [];
    department?.map((item) => {
      departmentRow.push(
        <tr>
          <td>{item.departmentName}</td>
          <td>
            <button
              className="btn btn-info"
              data-toggle="modal"
              data-target="#editModal"
              onClick={() => editClick(item)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              data-dismiss="modal"
              onClick={() => deleteDepartmentClick(item.id)}
            >
              Delete
            </button>
          </td>
        </tr>
      );
    });
    return departmentRow;

  };
  const ChangeHandler=(event)=>{
    SetDepartmentForm({...departmentForm,[event.target.name]:event.target.value});
    console.log(departmentForm); 
 };
 function editClick(data){
  //alert(data.departmentName);
 SetDepartmentForm(data);
}
function UpdateDepartmentsClick()
{
  axios
  .put("https://localhost:44375/api/Department/",departmentForm)
  .then(() => {
    alert("Data Updated");
    GetAllDepartments();
    //   SetEmployeeForm(initData);
  })
  .catch((e) => {
    console.log(e);
  });
}

function deleteDepartmentClick(id){
  axios.delete("https://localhost:44375/api/Department/"+id).then((d)=>{
    
      alert("Department Deleted");
      GetAllDepartments();
    
  }).catch((e)=>{
    alert('api is not working');
  })
 }

  return (
    <div>
      <div className="row">
        <div className="col-10">
          <h2 className="text-primary text-left">Department List</h2>
        </div>
        <div className="col-2">
          <button
            className="btn btn-primary"
            data-toggle="modal"
            data-target="#newModal"
            // onClick={() => }
          >
            New Department
          </button>
        </div>
      </div>
      <div className="col-10 offset-1">
        <table class="table table-striped table-bordered table-hover">
          <thead>
            <tr>
              <th>DepartmentName</th>

              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {RenderDepartments()}
            </tbody>
        </table>
      </div>
      {/* save */}
      <form>
        <div className="modal" id="newModal" role="dialog">
          <div className="modal-dialog">
            <div className="modal-content">
              {/* header */}
              <div className="modal-header">
                <div className="modal-title">New Department</div>
                <button className="close" data-dismiss="modal">
                  <span>&times;</span>
                </button>
              </div>
              {/* body */}
              <div className="modal-body">
                <div className="form-group row">
                  <label for="departmentName" className="col-sm-4">
                    Name
                  </label>
                  <div className="col-sm-8">
                    <input
                        onChange={ChangeHandler}
                      //    value={employeeForm.name}
                      className="form-control"
                      name="departmentName"
                      type="text"
                      id="departmentName"
                      placeholder="Department Name"
                    ></input>
                  </div>
                </div>
              </div>
              <div className="modal-footer">
                <button
                  className="btn btn-success"
                    onClick={SaveDepartments}
                  data-dismiss="modal"
                >
                  Save
                </button>
                <button className="btn btn-danger">Cancel</button>
              </div>
            </div>
          </div>
        </div>
      </form>
      {/* save code ended */}
      {/* Edit */}
      <form>
        <div className="modal" id="editModal" role="dialog">
          <div className="modal-dialog">
            <div className="modal-content">
              {/* header */}
              <div className="modal-header">
                <div className="modal-title">Edit Department</div>
                <button className="close" data-dismiss="modal">
                  <span>&times;</span>
                </button>
              </div>
              {/* body */}
              <div className="modal-body">
                <div className="form-group row">
                  <label for="departmentName" className="col-sm-4">
                    Name
                  </label>
                  <div className="col-sm-8">
                    <input
                        
                      className="form-control"
                      name="departmentName"
                      type="text"
                      id="departmentName"
                      placeholder="Department Name"
                      value={departmentForm.departmentName}
                       onChange={ChangeHandler}
                    ></input>
                  </div>
                </div>
              </div>
              <div className="modal-footer">
                <button
                  className="btn btn-success"
                    onClick={UpdateDepartmentsClick}
                  data-dismiss="modal"
                >
                  Update
                </button>
                <button className="btn btn-danger">Cancel</button>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default Department;
