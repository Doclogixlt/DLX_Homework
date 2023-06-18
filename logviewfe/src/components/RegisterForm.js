import React, { useState } from "react";
import "./styles.css";

const RegisterForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    // Perform registration logic with email, password, and confirmPassword
    console.log("Register form submitted");
  };

  return (
    <form className="form" onSubmit={handleSubmit}>
      <h2>Register</h2>
      <div>
        <label>Email:</label>
      </div>
      <div>
        <input
          className="inpt"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>

      <div>
        <label>Password:</label>
      </div>
      <div>
        <input
          className="inpt"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>
      <div>
        <label>Confirm Password:</label>
      </div>
      <div>
        <input
          className="inpt"
          type="password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
          required
        />
      </div>
      <div>
        <button className="btn" type="submit">
          Register
        </button>
      </div>
    </form>
  );
};

export default RegisterForm;
