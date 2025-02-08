import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { _post } from "../../utils/api"
import {ReactComponent as Avatar} from './avatar.svg';
import {ReactComponent as Reading} from './reading.svg';


export const Register = (props) => {
    const [email, setEmail] = useState('');
    const [pass, setPass] = useState('');
    const [confirmpass, setConfirmPass] = useState('');
    const [name, setName] = useState('');
    const [errorName, setErrorName] = useState('');
    const [errorEmail, setErrorEmail] = useState('');
    const [errorPass, setErrorPass] = useState('');
    const [errorConfirmPass, setErrorConfirmPass] = useState('');
    const history = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();

        setErrorName("");
        setErrorEmail("");
        setErrorPass("");
        setErrorConfirmPass("");

        if (!name) {
            setErrorName("Name cannot be empty!");
        } else if (!email) {
            setErrorEmail("Email cannot be empty!");
        } else if (!pass) {
            setErrorPass("Password cannot be empty!");
        } else if (pass !== confirmpass) {
            setErrorPass("Password and Confirm Password are not equal!");
            setErrorConfirmPass("Password and Confirmed Password are not equal!");
        }
        else {
            _post("https://localhost:44335/api/Auth/Register", {
                name:name,
                email:email,
                password: pass,
                role: "User",
            }).then(() => {
                console.log("succes");
                history("/");
            }).catch((err) => {
                console.log(err);
            })
        }
    } 

    return (
        <div className="App-auth">
            <div className="div-register">
                <div>
                    <Reading className="reading"/>
                    <h1 className="title">BOOKGRAM</h1>
                </div>
                <div className="auth-form-container-register">
                    <form className="register-form" onSubmit={handleSubmit}>
                        <div className="avatar"><Avatar /></div>

                        <h1 className="welcome-text">Join our team!</h1>
                        
                        { errorName && <div className="error">{errorName}</div> }
                        <label htmlFor="firstname">Name:</label>
                        <input className="input-register" value={name} onChange={(e) => setName(e.target.value)} placeholder="Name" id="firstname" name="name" />
                        
                        { errorEmail && <div className="error">{errorEmail}</div> }
                        <label htmlFor="email">Email:</label>
                        <input className="input-register" value = {email} onChange={(e) => setEmail(e.target.value)} type="email" placeholder="youremail@gmail.com" id="email" name="email" />

                        { errorPass && <div className="error">{errorPass}</div> }
                        <label htmlFor="password">Password:</label>
                        <input className="input-register" value = {pass} onChange={(e) => setPass(e.target.value)} type="password" placeholder="********" id="password" name="password" />
                        
                        { errorConfirmPass && <div className="error">{errorConfirmPass}</div> }
                        <label htmlFor="password">Confirm Password:</label>
                        <input className="input-register" value = {confirmpass} onChange={(e) => setConfirmPass(e.target.value)}  type="password" placeholder="********" id="confirmpass" name="confirmpass" />
                        
                        <button className="register-btn" type="submit"><b>Register</b></button>
                    </form>

                    <button className="link-btn-register" onClick={() => history("/")}>Already have an account? Login here.</button>
                </div>
            </div>
        </div>
    )
}