import React from 'react'
import AllUsers from './AllUsers';

export default function ReuseData() {
    var token = localStorage.getItem("userToken");
    
  return (
    <div>
        <AllUsers data={token}/>
    </div>
  )
}
