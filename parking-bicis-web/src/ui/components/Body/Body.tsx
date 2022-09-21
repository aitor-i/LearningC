import React, { Fragment, useContext } from "react";

import NewHistoryForm from "../NewHistoryForm";
import History from "../History";
import { LoginContext } from "../../store/loging-ctx";
import MainLoginPage from "../MainLoginPage";
import ErrorBoundary from "../ErrorBoundary/ErrorBoundary";
import Spinner from "../Spinner";

export const Body = () => {
  const { isLogged } = useContext(LoginContext);
  return (
    <Fragment>
      {isLogged ? (
        <>
          <ErrorBoundary>
            <History />
          </ErrorBoundary>
          <ErrorBoundary>
            <NewHistoryForm />
          </ErrorBoundary>
        </>
      ) : (
        <ErrorBoundary>
          <React.Suspense fallback={<Spinner />}>
            <MainLoginPage />
          </React.Suspense>
        </ErrorBoundary>
      )}
    </Fragment>
  );
};
