import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import AllUsers from './AllUsers'
import ConfirmEmail from './ConfirmEmail'
import Department from './Department'
import ForgotPassword from './ForgotPassword'
import Home from './Home'
import Login from './Login'
import Register from './Register'
import ResendEmail from './ResendEmail'
import ResetPassword from './ResetPassword'

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
        <Route path='/confirmEmail' element={<ConfirmEmail/>}/>       
        <Route path='/resetPassword' element={<ResetPassword/>}/>       
        <Route path='/forgotPassword' element={<ForgotPassword/>}/>       
        <Route path='/resendEmail' element={<ResendEmail/>}/>       


       </Routes>
       </BrowserRouter>
    </div>
  )
}

export default Routing