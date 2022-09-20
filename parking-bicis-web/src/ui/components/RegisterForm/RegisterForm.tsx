import React, { ChangeEvent, useState } from "react";
import { RegisterType } from "../../../core/domain/type/RegisterType";
import { postRegisterNewUser } from "../../../core/services/postRegisterNewUser";
import Spinner from "../Spinner";

export const RegisterForm = () => {
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [userType, setUserType] = useState(1);
  const [loadingState, setLoadingState] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");
  const registerRef = React.useRef<HTMLFormElement>(null);
  const nameHandler = (event: ChangeEvent<HTMLInputElement>) => {
    setName(event.target.value);
  };
  const passwordHandler = (event: ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  };
  const selectParkingHandler = (event: ChangeEvent<HTMLSelectElement>) => {
    setUserType(+event.target.value);
  };
  const submitHandler = async (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    event.preventDefault();
    setLoadingState("loading");
    try {
      const registerForm: RegisterType = {
        password,
        username: name,
        userTypeId: userType,
      };
      const response = await postRegisterNewUser(registerForm);
      alert(`Your id is ${response}`);
      setLoadingState("success");
    } catch (error) {
      alert(error);
      setLoadingState("error");
    } finally {
      if (registerRef.current) registerRef.current.reset();
    }
  };

  return (
    <form ref={registerRef}>
      <h2>Register</h2>
      <h3>Name</h3>
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
      <h3>Type</h3>
      <select onChange={selectParkingHandler} name="pname" id="pname">
        <option value={1}>Bike user</option>
        <option value={2}>Parking owner</option>
      </select>
      {loadingState !== "loading" ? (
        <button onClick={submitHandler}>Register</button>
      ) : (
        <Spinner />
      )}
    </form>
  );
};
