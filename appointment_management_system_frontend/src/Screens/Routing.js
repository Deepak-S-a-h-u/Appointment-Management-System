import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import AllUsers from './AllUsers'
import Department from './Department'
import Home from './Home'
import Login from './Login'
import NavBar from './NavBar'
import Register from './Register'

function Routing() {
  return (
    <div>
        <BrowserRouter>
       {/* <NavBar/> */}
       <Routes>
       <Route path='/' element={<Home/>}/>
        <Route path='/home' element={<Home/>}/>   
        <Route path='/department' element={<Department/>}/>   
        <Route path='/login' element={<Login/>}/>       
        <Route path='/register' element={<Register/>}/>       
        <Route path='/allUsers' element={<AllUsers/>}/>       


       </Routes>
       </BrowserRouter>
    </div>
  )
}

export default Routing