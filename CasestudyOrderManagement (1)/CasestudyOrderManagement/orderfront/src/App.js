import './App.css';
import React from 'react'
import ReactDOM from "react-dom/client";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './components/Login';
import Registration from './components/Registration';
import Dashboard from './components/Dashboard';
import Cart from './components/Cart';



function App() {
  return(
    <Router>
        <Routes>
            <Route path = '/' element={<Login/>} />
            <Route path = '/registration' element={<Registration/>} />
            <Route path = '/dashboard' element={<Dashboard/>} />
            <Route path = '/cart' element={<Cart/>} />
        </Routes>
    </Router>
)
}

export default App;