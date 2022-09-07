import React from "react";

import History from "./components/History";

import "./App.css";
import NewHistoryForm from "./components/NewHistoryForm";

function App() {
  return (
    <div className="App">
      <h1>Parking</h1>
      <History />
      <NewHistoryForm />
    </div>
  );
}

export default App;
