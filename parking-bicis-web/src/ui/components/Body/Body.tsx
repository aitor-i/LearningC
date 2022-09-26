import React, { Fragment, useContext } from "react";

import { LoginContext } from "../../store/loging-ctx";
import MainLoginPage from "../MainLoginPage";
import ErrorBoundary from "../ErrorBoundary/ErrorBoundary";
import Spinner from "../Spinner";
import BikeUserBody from "./BikeUserBody";
import ParkingOwnerBody from "./ParkingOwnerBody";

export const Body = () => {
  const { isLogged, user } = useContext(LoginContext);
  const { userType } = user;
  return (
    <Fragment>
      {isLogged ? (
        userType === 1 ? (
          <BikeUserBody />
        ) : (
          <ParkingOwnerBody />
        )
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
