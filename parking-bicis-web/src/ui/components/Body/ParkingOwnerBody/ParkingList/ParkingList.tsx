import { Parkings } from "../../../../../core/domain/type/Parkings";
import Spinner from "../../../Spinner";
import { useParkin } from "../useParking";
import "./parking-list.css";

interface Props {
  selectParkingHandler: (parking: Parkings) => void;
}

export const ParkingList = ({ selectParkingHandler }: Props) => {
  const { fetchingStatus, parkings, fetchParkings } = useParkin();

  return (
    <div className="parkings-list">
      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <h3>Parkings</h3>
        <p onClick={fetchParkings}>R</p>
      </div>
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
