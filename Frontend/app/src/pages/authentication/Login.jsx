import React, { useEffect, useState } from "react";
import { _post } from "../../utils/api";
import {ReactComponent as Avatar} from './avatar.svg';
import {ReactComponent as Reading} from './reading.svg';
import { useNavigate } from "react-router-dom";
import { saveToken } from "../../utils/storage";
import { getToken } from "../../utils/storage";
import { jwtDecode } from "jwt-decode";

export const Login = (props) => {
    const [email, setEmail] = useState('');
    const [pass, setPass] = useState('');
    const [error, setError] = useState('');
    const [token, setToken] = useState([]);
    const history = useNavigate();
    
    const handleSubmit = (e) => {
        
        e.preventDefault();
        console.log(email);

        _post("https://localhost:44335/api/Auth/Login", {
            email:email,
            password:pass
        }).then((response) => {
            if (response.data.success) {
                saveToken(response.data.accessToken);
                console.log("token: ", response.data.accessToken);
                history("/Home");
            } else {
                setError("Email and/or password is not valid!");
            }
        }).catch((err) => {
            console.log(err);
        }) 
    }

    useEffect(() => {
        if (getToken()) {
            setToken(jwtDecode(getToken()))
        }
        else {
            setToken("");
        };
    }, []);

    if (!token || token === "") {
        return (
            <div className="App-auth">
                <div className="div-login">   
                    <div>
                        <Reading className="reading"/>
                        <h1 className="title"> BOOKGRAM </h1>
                    </div>
                    <div className="auth-form-container-login">
                        <form className="login-form" onSubmit={handleSubmit}>
                            <div className="avatar"> <Avatar /> </div>

                            <h1 className="welcome-text">Welcome!</h1>
                            { error && <div className="error">{error}</div> }
                            <label htmlFor="email">Email:</label>
                            <input className="input-login" value = {email} onChange={(e) => setEmail(e.target.value)}
                                onKeyDown={(e) => {
                                    if (e.key === "Enter") {
                                    handleSubmit(e);
                                    }
                                }} type="email" placeholder="youremail@gmail.com" id="email" name="email" />

                            <label htmlFor="password">Password:</label>
                            <input className="input-login" value = {pass} onChange={(e) => setPass(e.target.value)} 
                                onKeyDown={(e) => {
                                    if (e.key === "Enter") {
                                    handleSubmit(e);
                                    }
                                }} type="password" placeholder="********" id="password" name="password" />
                            
                            <button id="recover-button" className="link-btn-recover" onClick={() => history("/Authentication/RecoverPassword")}>Forgot password?</button>

                            <button id="login-button" className="login-btn" type="submit"><b>Login</b></button>
                        </form>

                        <button id="register-button" className="link-btn-login" onClick={() => history("/Authentication/Register")}>Don't have an account? Register here.</button>
                    </div>
                </div>
            </div>
        );
    }
    else {
        history("/Home");
    }
}