import React, { useState } from "react";

interface Props {
  children: React.ReactNode;
}

const LoginContext = React.createContext({});

export const LoginContextProvider = ({ children }: Props) => {
  const [isLogged, setIsLogged] = useState(false);

  const loginHandler = () => {
    setIsLogged(true);
  };

  const logOutHandler = () => {
    setIsLogged(false);
  };

  return (
    <LoginContext.Provider value={{ isLogged, logOutHandler, loginHandler }}>
      {children}
    </LoginContext.Provider>
  );
};
