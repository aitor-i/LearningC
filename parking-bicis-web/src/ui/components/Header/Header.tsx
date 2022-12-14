import React, { useContext } from "react";
import { LoginContext } from "../../store/loging-ctx";

export const Header = () => {
  const { isLogged, logOutHandler, user } = useContext(LoginContext);
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
          <p style={{ color: "white" }}>
            {user.username} your Id: {user.usersId} your type:{" "}
            {user.userType === 1 ? "Bike user" : "Parking owner"}
          </p>
          <button style={{ padding: "1rem" }} onClick={logOutHandler}>
            Log out
          </button>
        </>
      ) : null}
    </div>
  );
};
