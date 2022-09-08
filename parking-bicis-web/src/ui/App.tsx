import React from "react";
import { LoginContextProvider } from "./store/loging-ctx";

import History from "./components/History";
import NewHistoryForm from "./components/NewHistoryForm";

import "./App.css";

function App() {
  return (
    <div className="App">
      <LoginContextProvider>
        <h1>Parking</h1>
        <History />
        <NewHistoryForm />
      </LoginContextProvider>
    </div>
  );
}

export default App;
