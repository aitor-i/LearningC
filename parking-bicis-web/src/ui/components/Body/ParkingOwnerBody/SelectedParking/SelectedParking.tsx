import { Suspense, useState } from "react";
import { Parkings } from "../../../../../core/domain/type/Parkings";
import { EditSelectedParking } from "./EditSelectedParking/EditSelectedParking";

import { VscEdit } from "react-icons/vsc";

import "./selected-parking.css";
import Spinner from "../../../Spinner";
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
          <Suspense fallback={<Spinner />}>
            <EditSelectedParking
              selectedParking={selectedParking}
              changeToViewMode={changeToViewMode}
            />
          </Suspense>
        ) : (
          <div className="parking-data">
            <p>{selectedParking?.id}</p>
            <p>{selectedParking?.parkinName}</p>
            <p>{selectedParking?.username}</p>
            <p className="edit-button" onClick={changeToEditModeHandler}>
              <VscEdit />
            </p>
          </div>
        )}
      </div>
    );
  else {
    return <div style={{ display: "none" }}></div>;
  }
};
