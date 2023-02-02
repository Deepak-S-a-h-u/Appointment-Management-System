import axios from 'axios'
import React from 'react'
import { useEffect } from 'react'
import { Link } from 'react-router-dom'
function ConfirmEmail() {
    // const valuesInit={
    //     userId:"",
    //     code:""
    // }
    //const[values,SetValues]=useState(valuesInit)

    // let { userId } = useParams();
    // console.log(userId)
    
    // let {code}=useParams();
    // console.log(code)
    
    useEffect(() => {
        debugger
        const myKeyValues=window.location.search;
        const urlParms=new URLSearchParams(myKeyValues);
        const UserId=urlParms.get('UserId');
        const Code=urlParms.get('code');
        console.log(UserId,Code)
      const values={UserId,Code}
      console.log(values);
       axios.post("https://localhost:44338/api/RegisterUser/ConfirmEmail/",values);
      }, [])
    
  return (
    <div>
        <h1>Email confirmation status</h1>
        <br/>
        <h3>Your email is confirmed 
            <br/>
            <br/>
            <br/>
            Now login with your Username And password </h3>
          

        <Link to="/login" class="btn btn-outline-success my-2 my-sm-0">Login</Link>

    </div>
  )
}

export default ConfirmEmail