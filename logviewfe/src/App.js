import React from "react";
import { Route, Switch } from "react-router-dom";
import LoginForm from "./components/LoginForm";
import RegisterForm from "./components/RegisterForm";
import Dashboard from "./components/Dashboard";
import "./components/styles.css";

const App = () => {
  return (
    <div className="login-container">
      <Switch>
        <Route exact from="/" render={(props) => <LoginForm {...props} />} />
        <Route
          exact
          from="/register"
          render={(props) => <RegisterForm {...props} />}
        />
        <Route
          exact
          from="/dashboard"
          render={(props) => <Dashboard {...props} />}
        />
      </Switch>
    </div>
  );
};

export default App;
