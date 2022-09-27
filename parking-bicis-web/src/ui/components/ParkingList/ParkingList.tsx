import Spinner from "../Spinner";
import { useParkin } from "./useParking";
import "./parking-list.css";

export const ParkingList = () => {
  const { fetchingStatus, parkings } = useParkin();

  return (
    <div className="parkings-list">
      <h3>Parkings</h3>
      {fetchingStatus !== "loading" && fetchingStatus === "success" ? (
        parkings.map((parkin) => <p>{parkin.parkinName}</p>)
      ) : (
        <Spinner />
      )}
    </div>
  );
};
