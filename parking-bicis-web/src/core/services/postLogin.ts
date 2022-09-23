import { LoginForm } from "../domain/type/LoginForm";

export const postLogin = async (loginForm: LoginForm) => {
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
