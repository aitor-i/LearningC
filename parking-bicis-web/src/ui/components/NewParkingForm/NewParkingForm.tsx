import React, { useContext, useState } from "react";
import { postNewParking } from "../../../core/services/postNewParking";
import { LoginContext } from "../../store/loging-ctx";
import Spinner from "../Spinner";

export const NewParkingForm = () => {
  const [parkingName, setParkingName] = useState("");
  const [loadingState, setLoadingState] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");
  const { user } = useContext(LoginContext);
  const parkingNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setParkingName(event.target.value);
  };

  const publishHandler = async (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    event.preventDefault();
    try {
      setLoadingState("loading");
      const res: number = await postNewParking({
        usersId: user.usersId,
        parkinName: parkingName,
      });

      alert(`Parking published, parking id: ${res}`);
      setLoadingState("success");
    } catch (error) {
      alert(error);
      setLoadingState("error");
    }
  };

  return (
    <form>
      <h3>Parking Name</h3>
      <input type="text" name="parking-name" onChange={parkingNameHandler} />
      {loadingState === "loading" ? (
        <Spinner />
      ) : (
        <button onClick={publishHandler}>Publish</button>
      )}
    </form>
  );
};
