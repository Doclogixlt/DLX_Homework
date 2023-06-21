import React, { useState } from "react";
import "./styles.css";

const RegisterForm = (props) => {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const { history } = props;

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      console.log("Passwords do not match");
      return;
    }

    try {
      const response = await fetch("https://localhost:7025/auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ name, password }),
      });

      if (response.ok) {
        // Handle successful registration
        history.push("/");
        console.log("Registered successfully");
      } else {
        // Handle registration failure
        console.log("Registration failed");
      }
    } catch (error) {
      console.log("Error occurred during registration:", error);
    }
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
          type="name"
          value={name}
          onChange={(e) => setName(e.target.value)}
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
