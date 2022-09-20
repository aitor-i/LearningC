import { LoginForm } from "../domain/type/LoginForm";

export const postLogin = async (loginForm: LoginForm) => {
  const response = fetch("http://localhost:6168/Users/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(loginForm),
  });

  if (!(await response).ok) throw new Error((await response).toString());

  return (await response).json();
};
