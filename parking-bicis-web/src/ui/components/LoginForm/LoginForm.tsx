import React, { useState } from "react";
import { postLogin } from "../../../core/services/postLogin";
import Spinner from "../Spinner";

export const LoginForm = () => {
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

  return (
    <form onSubmit={submitHandler}>
      <h2>Login </h2>
      <h3>Username</h3>

      <input
        type="text"
        name="username"
        onChange={nameHandler}
        aria-label="username"
      />
      <h3>Password</h3>
      <input
        type="password"
        name="'password"
        onChange={passwordHandler}
        aria-label="password"
      />
      <p>{userId}</p>
      {fetchingStatus === "loading" ? <Spinner /> : <button>Submit</button>}
    </form>
  );
};
