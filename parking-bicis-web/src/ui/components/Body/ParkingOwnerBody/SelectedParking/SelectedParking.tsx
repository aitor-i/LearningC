import { useState } from "react";
import { Parkings } from "../../../../../core/domain/type/Parkings";
import { EditSelectedParking } from "./EditSelectedParking/EditSelectedParking";
import "./selected-parking.css";
interface Props {
  selectedParking: Parkings | undefined;
}

export const SelectedParking = ({ selectedParking }: Props) => {
  const [isEditMode, setIsEditMode] = useState(false);
  const changeToEditModeHandler = () => {
    setIsEditMode(true);
  };

  const changeToViewMode = () => {
    setIsEditMode(false);
  };
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
        {isEditMode ? (
          <EditSelectedParking
            selectedParking={selectedParking}
            changeToViewMode={changeToViewMode}
          />
        ) : (
          <div className="parking-data">
            <p>{selectedParking?.id}</p>
            <p>{selectedParking?.parkinName}</p>
            <p>{selectedParking?.username}</p>
            <button onClick={changeToEditModeHandler}>Edit</button>
          </div>
        )}
      </div>
    );
  else {
    return <div style={{ display: "none" }}></div>;
  }
};
