import Spinner from "../Spinner";
import { useNewParking } from "./useNewParking";
import "./new-parking-form.css";

export const NewParkingForm = () => {
  const { loadingState, parkingNameHandler, publishHandler } = useNewParking();

  return (
    <form className="parking-form">
      <h3>Parking Name</h3>
      <input type="text" name="parking-name" onChange={parkingNameHandler} />
      <label>New Parking's Name</label>
      {loadingState === "loading" ? (
        <Spinner />
      ) : (
        <button onClick={publishHandler}>Publish</button>
      )}
    </form>
  );
};
