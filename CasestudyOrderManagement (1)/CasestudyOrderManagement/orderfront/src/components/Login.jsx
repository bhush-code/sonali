import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import Form from 'react-bootstrap/Form';
import Button from "react-bootstrap/Button";
import './Login.css';




export default function Login() {
   

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    // const [Type, setType] = useState("");
    


    const navigate = useNavigate();

    function gotoRegisterPage() {
        navigate('/registration');
    }

    async function handleSubmit(event) {
        event.preventDefault();
        
        
        let res = await axios.post(`https://localhost:44343/api/User/login?email=${email}&password=${password}`)
        .then((response) =>{
            console.log(response.data)
            
            if((response.data === undefined) || (response.data === null)){
                alert("Invalid Login");
            }
            else if(response.data.type === "guest"){
                alert("User Login")
                navigate('/dashboard', {
                    state:{
                        userId:response.data.id
                        
                    }
                })
            }
            else if(response.data.userType === "Admin"){
                alert("Admin Login")
                navigate('/admindashboard', {
                    state:{
                        userId:response.data.id,
                        userType:response.data.userType
                    }
                })
            }
        })
        
    }

    return (
    
            <div>
                    <h1>Login</h1>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group className="w-50" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" value={email} onChange={(e) => setEmail(e.target.value)} />
                        </Form.Group>

                        <Form.Group className="w-50" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Enter Password" value={password} onChange={(e) => setPassword(e.target.value)} />
                        </Form.Group>

                        {/* <Form.Group className="w-50" controlId="formBasicUserType">
                            <Form.Label>Type</Form.Label>
                            <Form.Control type="string" placeholder="Enter User Type" value={Type} onChange={(e) => setType(e.target.value)} />
                        </Form.Group> */}

                        <br></br>
                        <Button variant='primary' type='submit'>Login</Button>
                        <br></br>
                        <br></br>
                        <Button variant='secondary' type='submit' onClick={gotoRegisterPage}>Go to Register Page</Button>
                        <br></br>
                    </Form>

            </div>
        

    );
}

