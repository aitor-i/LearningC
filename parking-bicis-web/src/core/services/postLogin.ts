import { LoginForm } from "../domain/type/LoginForm";

export const postLogin = async (loginForm: LoginForm) => {
  return await (
    await fetch("http://localhost:6168/Users/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(loginForm),
    })
  ).json();
};
