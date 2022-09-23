import { RegisterType } from "../domain/type/RegisterType";

export const postRegisterNewUser = async (newUserForm: RegisterType) => {
  const response = fetch(`${process.env.REACT_APP_API_URL}/Users/NewUser`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newUserForm),
  });

  if (!(await response).ok) throw new Error((await response).toString());
  return (await response).json();
};
