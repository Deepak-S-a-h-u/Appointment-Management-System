import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom'

function NavBar() {
  const navigate=useNavigate();
  const[userToken,setUserToken]=useState();
  const[userRole,setUserRole]=useState();

  useEffect(()=>{
      var userToken=localStorage.getItem("userToken");
      if(userToken)
      {
        setUserToken(userToken);
      }
      var role=localStorage.getItem("Role");
      console.log(role)
      if(role!=null)
      {
        setUserRole(role);
        console.log(userRole)
      }

  },[]);
  const logout=()=>{
    localStorage.clear();
    navigate("/login");
}

  return (
    
    <div>

         <div>
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
 

 <div class="collapse navbar-collapse" id="navbarSupportedContent">
   <ul class="navbar-nav mr-auto">
     <li class="nav-item active">
       <Link className='nav-link' to='/home'>Home</Link>
     </li>
     
     <li class="nav-item active">
       <Link class="nav-link" to="/department">Department</Link>
     </li>

     {userRole!="Admin_User"?(<div/>):(
     <li class="nav-item active">
       <Link class="nav-link" to="/allUsers">All Users</Link>
     </li>
     )}

     {userToken?(<div/>):(
      <li class="nav-item active">
       {/* <Link className='nav-link' to='/login'>Login</Link> */}

     </li>
      )
    }
     {userToken || userRole=="Admin_User"?(<div/>):(
      <Link to="/register" class="btn btn-outline-success my-2 my-sm-2">Register</Link>
    )
    }

{userRole=="Admin_User"?(
     <li class="nav-item active">
             <Link to="/register" class="btn btn-outline-success my-2 my-sm-2">Register</Link>
     </li>
     ):(<div/>)
     }

    {userToken?
       (<a onClick={logout} className="btn btn-success">Logout</a>
       ):
       (
        <Link to="/login" class="btn btn-outline-success my-4 my-sm-2">Login</Link>
      )
    }
     
   </ul>
    
 </div>

   </nav>
    </div>
   
    </div>
  )
}

export default NavBar