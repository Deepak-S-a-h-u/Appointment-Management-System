import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Department from './Department'
import Home from './Home'
import NavBar from './NavBar'

function Routing() {
  return (
    <div>
        <BrowserRouter>
       <NavBar/>
       <Routes>
       <Route path='/' element={<Home/>}/>
        <Route path='/home' element={<Home/>}/>   
        <Route path='/department' element={<Department/>}/>       

       </Routes>
       </BrowserRouter>
    </div>
  )
}

export default Routing