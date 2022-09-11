import React, { useState } from "react";
import { postLogin } from "../../../core/services/postLogin";
import Spinner from "../Spinner";
import { useLogin } from "./useLogin";

export const LoginForm = () => {
  const {
    fetchingStatus,
    nameHandler,
    passwordHandler,
    submitHandler,
    userId,
  } = useLogin();
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
