import Spinner from "../Spinner";
import { useNewParking } from "./useNewParking";

export const NewParkingForm = () => {
  const { loadingState, parkingNameHandler, publishHandler } = useNewParking();

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
