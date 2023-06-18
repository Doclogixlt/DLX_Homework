import React, { useState } from "react";

const LoginForm = () => {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    // Perform login logic with email and password
    console.log("Login form submitted");
  };

  return (
    <form className="form" onSubmit={handleSubmit}>
      <h2>Login</h2>

      <div>
        <label>Name:</label>
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
        <button className="btn" type="submit">
          Login
        </button>
      </div>
    </form>
  );
};

export default LoginForm;
