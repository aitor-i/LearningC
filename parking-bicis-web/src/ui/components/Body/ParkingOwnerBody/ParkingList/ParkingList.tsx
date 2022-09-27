import Spinner from "../../../Spinner";
import { useParkin } from "./useParking";
import "./parking-list.css";

export const ParkingList = () => {
  const { fetchingStatus, parkings, selectParkingHandler } = useParkin();

  return (
    <div className="parkings-list">
      <h3>Parkings</h3>
      {fetchingStatus !== "loading" && fetchingStatus === "success" ? (
        parkings.map((parkin) => {
          return (
            <p onClick={() => selectParkingHandler(parkin)} key={parkin.id}>
              {parkin.parkinName}
            </p>
          );
        })
      ) : (
        <Spinner />
      )}
    </div>
  );
};
