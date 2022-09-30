import React, { useState } from "react";
import { Parkings } from "../../../../../../core/domain/type/Parkings";

interface Props {
  selectedParking: Parkings | undefined;
}

export const EditSelectedParking = ({ selectedParking }: Props) => {
  const [newParkingName, setNewParkingName] = useState(
    selectedParking?.parkinName
  );
  const editNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewParkingName(event.target.value);
  };
  return (
    <div className="parking-data">
      <p>{selectedParking?.id}</p>
      <input
        type="text"
        name="parking-name"
        onChange={editNameHandler}
        value={newParkingName}
      />
      <p>{selectedParking?.username}</p>
      <button>Save</button>
    </div>
  );
};
