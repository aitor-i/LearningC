import React from "react";
import { LoginContextProvider } from "./store/loging-ctx";

import History from "./components/History";
import NewHistoryForm from "./components/NewHistoryForm";

import "./App.css";
import { Header } from "./components/Header/Header";
import { LoginForm } from "./components/LoginForm/LoginForm";

function App() {
  return (
    <div className="App">
      <LoginContextProvider>
        <Header />
        <History />
        <LoginForm />
        <NewHistoryForm />
      </LoginContextProvider>
    </div>
  );
}

export default App;
