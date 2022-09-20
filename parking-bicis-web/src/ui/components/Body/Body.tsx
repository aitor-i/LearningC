import React, { Fragment, useContext } from "react";

import { LoginForm } from "../LoginForm/LoginForm";
import NewHistoryForm from "../NewHistoryForm";
import History from "../History";
import { LoginContext } from "../../store/loging-ctx";
import RegisterForm from "../RegisterForm";

export const Body = () => {
  const { isLogged } = useContext(LoginContext);
  return (
    <Fragment>
      {isLogged ? (
        <>
          <History />
          <NewHistoryForm />
        </>
      ) : (
        <div
          className="login-container"
          style={{ display: "flex", gap: "1.5rem" }}
        >
          <LoginForm />
          <RegisterForm />
        </div>
      )}
    </Fragment>
  );
};
