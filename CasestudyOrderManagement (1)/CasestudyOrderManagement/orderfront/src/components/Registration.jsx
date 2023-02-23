import axios from "axios";
import Button from 'react-bootstrap/Button';
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Form from 'react-bootstrap/Form';


export default function Registration() {
    const [Name, setName] = useState("");
    const [Email, setEmail] = useState("");
    const [Password, setPassword] = useState("");
    const [Type, setType] = useState("");
    const [Status, setStatus] = useState("");
    

    const navigate = useNavigate();
    let res = {};


    function gotoSignInPage() {
        navigate('/');
    }


    function handleSubmit() {
        const User = { Name, Email, Password, Type, Status}
        let result =  axios.post(`https://localhost:44343/api/User`, User).then(response => {
            alert("Submitting to database")
            console.log(response.data)
            res = response.data
        })
        navigate('/');
    }

    return (
        <>
            <div>
                <center>
                    <h4>Registration</h4>
                    <Form>
                        <Form.Group className="w-50" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" value={Email} onChange={(e) => setEmail(e.target.value)} />
                            <Form.Text className="text-muted">
                                We'll never share your email with anyone else.
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="w-50" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Enter Password" value={Password} onChange={(e) => setPassword(e.target.value)} />
                        </Form.Group>

                        <Form.Group className="w-50" controlId="formBasicUserName">
                            <Form.Label>Username</Form.Label>
                            <Form.Control type="string" placeholder="Enter Username" value={Name} onChange={(e) => setName(e.target.value)} />
                        </Form.Group>

                        
                        <Form.Group className="w-50" controlId="formBasicUserType">
                            <Form.Label>Type</Form.Label>
                            <Form.Control type="string" placeholder="Enter User Type" value={Type} onChange={(e) => setType(e.target.value)} />
                        </Form.Group>

                        <Form.Group className="w-50" controlId="formBasicUserStatus">
                            <Form.Label>Status</Form.Label>
                            <Form.Control type="int" placeholder="Enter User Status" value={Status} onChange={(e) => setStatus(e.target.value)} />
                        </Form.Group>

                        <br></br>
                        <Button variant='primary' type='submit' onClick={handleSubmit}>SignUp</Button>
                        <br></br>
                        <br></br>
                        <Button variant='secondary' type='submit' onClick={gotoSignInPage}>Go to Sign In Page</Button>
                    </Form>


                </center>
                <br></br>
            </div>
        </>
    )
}
