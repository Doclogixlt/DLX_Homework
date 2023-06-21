import React, { useState } from "react";

const LoginForm = (props) => {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");

  const { history } = props;

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await fetch("https://localhost:7025/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ name, password }),
      }).then(async (response) => {
        if (response.ok) {
          var data = await response.json();
          localStorage.setItem("token", data.token);
          history.push("/dashboard");
          console.log("Logged in successfully");
        } else {
          console.log("Login failed");
        }
      });
    } catch (error) {
      console.log("Error occurred during login:", error);
    }
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
      <div>
        If you don't have an account go to
        <button onClick={() => history.push("/register")}>Register</button>
      </div>
    </form>
  );
};

export default LoginForm;
