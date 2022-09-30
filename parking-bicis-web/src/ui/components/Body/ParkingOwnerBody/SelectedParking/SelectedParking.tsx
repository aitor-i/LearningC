import { Parkings } from "../../../../../core/domain/type/Parkings";
import { EditSelectedParking } from "./EditSelectedParking/EditSelectedParking";
import "./selected-parking.css";
interface Props {
  selectedParking: Parkings | undefined;
}

export const SelectedParking = ({ selectedParking }: Props) => {
  if (selectedParking)
    return (
      <div className="selected-parking-container">
        <h3>{selectedParking?.parkinName}</h3>
        <div className="parking-data title">
          <p>Id</p>
          <p>Parking name</p>
          <p>Username</p>
          <p></p>
        </div>
        <div className="parking-data">
          <p>{selectedParking?.id}</p>
          <p>{selectedParking?.parkinName}</p>
          <p>{selectedParking?.username}</p>
          <button>Edit</button>
        </div>
        <EditSelectedParking selectedParking={selectedParking} />
      </div>
    );
  else {
    return <div style={{ display: "none" }}></div>;
  }
};
