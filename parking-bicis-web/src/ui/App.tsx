import { LoginContextProvider } from "./store/loging-ctx";

import Body from "./components/Body";

import "./App.css";
import { Header } from "./components/Header/Header";

function App() {
  return (
    <div className="App">
      <LoginContextProvider>
        <Header />
        <Body />
      </LoginContextProvider>
    </div>
  );
}

export default App;
