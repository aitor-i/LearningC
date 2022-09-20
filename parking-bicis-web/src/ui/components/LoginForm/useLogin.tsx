import React, { useContext, useState } from "react";
import { postLogin } from "../../../core/services/postLogin";
import { LoginContext } from "../../store/loging-ctx";

export const useLogin = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [fetchingStatus, setFetchingStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");

  const { setUserIdHandler } = useContext(LoginContext);

  const nameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setUsername(event.target.value);
  };

  const passwordHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  };

  const login = async () => {
    setFetchingStatus("loading");
    try {
      const response = await postLogin({ username, password });
      setUserIdHandler(response);
      setFetchingStatus("success");
    } catch (error) {
      setFetchingStatus("error");
    }
  };

  const submitHandler = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    login();
  };

  return {
    submitHandler,
    nameHandler,
    passwordHandler,
    fetchingStatus,
  };
};
