import { LoginForm } from "../domain/type/LoginForm";
import { LoginResponse } from "../domain/type/LoginResponse";

export const postLogin: (
  loginForm: LoginForm
) => Promise<LoginResponse> = async (loginForm) => {
  const response = fetch(`${process.env.REACT_APP_API_URL}/Users/login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(loginForm),
  });

  if (!(await response).ok) {
    throw new Error((await response).toString());
  }

  return (await response).json();
};
