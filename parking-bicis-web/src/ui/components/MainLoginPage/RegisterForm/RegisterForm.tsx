import Spinner from "../../Spinner";
import { useRegisterUser } from "./useRegisterUser";
import "./register-form.css";

export const RegisterForm = () => {
  const {
    loadingState,
    nameHandler,
    passwordHandler,
    selectParkingHandler,
    submitHandler,
    registerRef,
  } = useRegisterUser();

  return (
    <form className="register-form" ref={registerRef}>
      <h2>Register</h2>
      <input
        type="text"
        name="username"
        onChange={nameHandler}
        aria-label="username"
      />
      <label>Name</label>
      <input
        type="password"
        name="'password"
        onChange={passwordHandler}
        aria-label="password"
      />
      <label>Password</label>
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
