import Spinner from "../Spinner";
import { useParkin } from "./useParking";

export const ParkingList = () => {
  const { fetchingStatus, parkings } = useParkin();

  return (
    <div>
      {fetchingStatus !== "loading" && fetchingStatus === "success" ? (
        parkings.map((parkin) => <p>{parkin.parkinName}</p>)
      ) : (
        <Spinner />
      )}
    </div>
  );
};
