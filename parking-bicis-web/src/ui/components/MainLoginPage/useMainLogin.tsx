import { useState } from "react";

export const useMainLogin = () => {
  const [isLoginMode, setIsLoginMode] = useState(true);
  const setRegisterHandler = () => {
    setIsLoginMode(false);
  };

  const setLoginModeHandler = () => {
    setIsLoginMode(true);
  };
  return { isLoginMode, setLoginModeHandler, setRegisterHandler };
};
