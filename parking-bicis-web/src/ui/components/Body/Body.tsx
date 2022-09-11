import React, { Fragment, useContext } from "react";

import { LoginForm } from "../LoginForm/LoginForm";
import NewHistoryForm from "../NewHistoryForm";
import History from "../History";
import { LoginContext } from "../../store/loging-ctx";

export const Body = () => {
  const { isLogged } = useContext(LoginContext);
  return (
    <Fragment>
      {isLogged ? (
        <>
          <History />
          <LoginForm />
        </>
      ) : (
        <NewHistoryForm />
      )}
    </Fragment>
  );
};
