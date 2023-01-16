import React from 'react'
import { Link } from 'react-router-dom'

function NavBar() {
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
      
     
   </ul>
    
 </div>
   </nav>
    </div>
    </div>
  )
}

export default NavBar