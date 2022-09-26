import React, { useState } from "react";
import { LoginResponse } from "../../core/domain/type/LoginResponse";

interface Props {
  children: React.ReactNode;
}

const defaultLoginData: LoginResponse = {
  isLogged: false,
  usersId: NaN,
  userType: NaN,
  username: "",
  password: null,
};

export const LoginContext = React.createContext({
  isLogged: false,
  loginHandler: () => {},
  logOutHandler: () => {},
  setUserHandler: (user: LoginResponse) => {},
  user: defaultLoginData,
});

export const LoginContextProvider = ({ children }: Props) => {
  const [isLogged, setIsLogged] = useState(false);
  const [user, setUser] = useState<LoginResponse>(defaultLoginData);

  const loginHandler = () => {
    setIsLogged(true);
  };

  const logOutHandler = () => {
    setIsLogged(false);
  };

  const setUserHandler = (user: LoginResponse) => {
    setUser(user);
    if (user) {
      loginHandler();
    }
  };

  return (
    <LoginContext.Provider
      value={{
        isLogged,
        logOutHandler,
        loginHandler,
        setUserHandler,
        user: user,
      }}
    >
      {children}
    </LoginContext.Provider>
  );
};
