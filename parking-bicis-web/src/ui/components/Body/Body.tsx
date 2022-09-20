import React, { Fragment, useContext } from "react";

import NewHistoryForm from "../NewHistoryForm";
import History from "../History";
import { LoginContext } from "../../store/loging-ctx";
import MainLoginPage from "../MainLoginPage";

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
        <MainLoginPage />
      )}
    </Fragment>
  );
};
