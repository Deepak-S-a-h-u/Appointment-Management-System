import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom'

function NavBar() {
  const navigate=useNavigate();
  const[userToken,setUser]=useState();
  useEffect(()=>{
      var userToken=localStorage.getItem("userToken");
      if(userToken)
      {
        setUser(userToken);
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
       <Link class="nav-link" to="/department">Designation</Link>
     </li>
     
     <li class="nav-item active">
       <Link class="nav-link" to="/allUsers">All Users</Link>
     </li>

     {userToken?(<div/>):(
      <li class="nav-item active">
       {/* <Link className='nav-link' to='/login'>Login</Link> */}

     </li>
      )
    }
     {userToken?(<div/>):(
      <Link to="/register" class="btn btn-outline-success my-2 my-sm-0">Register</Link>
    )
    }
    {userToken?
       (<a onClick={logout} className="btn btn-success">Logout</a>
       ):
       (
        <Link to="/login" class="btn btn-outline-success my-2 my-sm-0">Login</Link>
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