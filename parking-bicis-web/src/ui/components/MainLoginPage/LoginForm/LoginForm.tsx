import Spinner from "../../Spinner";
import { useLogin } from "./useLogin";

import "./login-form.css";

export const LoginForm = () => {
  const { fetchingStatus, nameHandler, passwordHandler, submitHandler } =
    useLogin();
  return (
    <form className="login-form" onSubmit={submitHandler}>
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
      {fetchingStatus === "loading" ? <Spinner /> : <button>Submit</button>}
    </form>
  );
};
