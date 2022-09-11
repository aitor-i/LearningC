import React, { useContext } from "react";
import { LoginContext } from "../../store/loging-ctx";

export const Header = () => {
  const { isLogged, logOutHandler, userID } = useContext(LoginContext);
  return (
    <div
      style={{
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <h1>Parking</h1>
      {isLogged ? (
        <>
          <p style={{ color: "white" }}>Your id is: {userID}</p>
          <button style={{ padding: "1rem" }} onClick={logOutHandler}>
            Log out
          </button>
        </>
      ) : null}
    </div>
  );
};
