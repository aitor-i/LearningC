import React, { useState } from "react";

interface Props {
  children: React.ReactNode;
}

export const LoginContext = React.createContext({
  isLogged: false,
  loginHandler: () => {},
  logOutHandler: () => {},
  setUserIdHandler: (id: number) => {},
  userID: NaN,
});

export const LoginContextProvider = ({ children }: Props) => {
  const [isLogged, setIsLogged] = useState(false);
  const [userId, setUserId] = useState<number>(NaN);

  const loginHandler = () => {
    setIsLogged(true);
  };

  const logOutHandler = () => {
    setIsLogged(false);
  };

  const setUSerIdHandler = (id: number) => {
    setUserId(id);
  };

  return (
    <LoginContext.Provider
      value={{
        isLogged,
        logOutHandler,
        loginHandler,
        setUserIdHandler: setUSerIdHandler,
        userID: userId,
      }}
    >
      {children}
    </LoginContext.Provider>
  );
};
