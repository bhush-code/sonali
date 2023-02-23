import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import Form from 'react-bootstrap/Form';
import Button from "react-bootstrap/Button";
import { useEffect, useState } from "react";
import {ListGroupItem ,ListGroup, Col} from 'react-bootstrap';

export default class Dashboard extends React.Component {
    
    state = {
        products: []
      }


    // function gotoSignInPage() {
    //     navigate('/');
    // function handleSubmit() {
        
    //     let result =  axios.get(`https://localhost:44343/api/Product`).then(response => {
    //         console.log(response.data)
    //         const products = res.data;
    //         this.setState({ products });
    //     })
    // }

    componentDidMount() {
        axios.get(`https://localhost:44343/api/Product`).then(response => {
            console.log(response.data)
            const products = response.data;
            this.setState({ products });
        })
    }

    render() {
        return (
            <div>
                <center>
                    <label>Welcome to Dashboard</label>
                </center>
                <ListGroup>
                        <ListGroupItem href="product">Dashboard</ListGroupItem>
                        
                        <ListGroupItem onClick={"alertClicked"}>Trigger an alert</ListGroupItem>
                </ListGroup>           
    
            </div>
        );
    }

    
}


    
