import { LoginForm } from "./LoginForm/LoginForm";
import RegisterForm from "./RegisterForm";
import { useMainLogin } from "./useMainLogin";
import "./main-login-page.css";

export const MainLoginPage = () => {
  const { isLoginMode, setLoginModeHandler, setRegisterHandler } =
    useMainLogin();
  return (
    <div>
      {isLoginMode ? (
        <>
          <LoginForm />
          <p className="change-form" onClick={setRegisterHandler}>
            Register
          </p>
        </>
      ) : (
        <>
          <RegisterForm />
          <p className="change-form" onClick={setLoginModeHandler}>
            Login
          </p>
        </>
      )}
    </div>
  );
};
