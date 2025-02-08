import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export const RecoverPassword = (props) => {
  const history = useNavigate();
  const [email, setEmail] = useState("");
  const [newPass, setNewPass] = useState("");


  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(email);
  };

  return (
    <div className="App-auth">
      <form className="recover-form" onSubmit={handleSubmit}>
        <h1 className="welcome-text">Recover your password</h1>

        <label htmlFor="email">Email:</label>
        <input
          className="input-login"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          type="email"
          placeholder="youremail@gmail.com"
          id="email"
          name="email"
        />

        <label htmlFor="password">New Password:</label>
        <input
          className="input-login"
          value={newPass}
          onChange={(e) => setNewPass(e.target.value)}
          type="password"
          placeholder="********"
          id="password"
          name="password"
        />

        <button className="login-btn" onClick={() => history("/")} type="submit">
          <b>Done</b>
        </button>
      </form>
    </div>
  );
};
