import React from "react";
import LoginForm from "./components/LoginForm";
import RegisterForm from "./components/RegisterForm";
import "./components/styles.css";

const App = () => {
  return (
    <div className="login-container">
      <LoginForm />
      <RegisterForm />
    </div>
  );
};

export default App;
