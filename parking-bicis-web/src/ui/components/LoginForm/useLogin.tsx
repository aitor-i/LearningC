import React, { useState } from "react";
import { postLogin } from "../../../core/services/postLogin";

export const useLogin = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [userId, setUserId] = useState(0);
  const [fetchingStatus, setFetchingStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");

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
      setUserId(response.userId);
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
    userId,
  };
};
