import React, { useContext } from "react";
import { LoginContext } from "../../store/loging-ctx";

export const Header = () => {
  const { isLogged, logOutHandler, loginHandler } = useContext(LoginContext);
  return (
    <div style={{ display: "flex", justifyContent: "space-between" }}>
      <h1>Parking</h1>
      {isLogged ? (
        <button onClick={logOutHandler}>Log out</button>
      ) : (
        <button onClick={loginHandler}>Login</button>
      )}
    </div>
  );
};
