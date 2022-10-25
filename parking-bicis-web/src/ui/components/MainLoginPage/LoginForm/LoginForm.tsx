import Spinner from "../../Spinner";
import { useLogin } from "./useLogin";
import RenderToast from "../../Toast";

import "./login-form.css";

export const LoginForm = () => {
  const { fetchingStatus, nameHandler, passwordHandler, submitHandler } =
    useLogin();
  return (
    <>
      {fetchingStatus === "error" && (
        <RenderToast className="toast-error" children={<p>Error</p>} />
      )}
      <form className="login-form" onSubmit={submitHandler}>
        <h2>Login </h2>

        <input
          type="text"
          name="username"
          onChange={nameHandler}
          aria-label="username"
          className="username"
          required
        />
        <label className="username">Username</label>
        <input
          type="password"
          name="'password"
          onChange={passwordHandler}
          aria-label="password"
          className="password"
          required
        />
        <label className="password">Password</label>
        {fetchingStatus === "error" && (
          <p style={{ color: "red" }}>Error login</p>
        )}
        {fetchingStatus === "loading" ? <Spinner /> : <button>Submit</button>}
      </form>
    </>
  );
};
