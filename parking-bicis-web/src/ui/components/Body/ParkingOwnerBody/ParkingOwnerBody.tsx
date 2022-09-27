import React, { useState } from "react";
import History from "../../History";
import NewParkingForm from "../../NewParkingForm";
import { ParkingList } from "./ParkingList/ParkingList";
import SelectedParking from "./SelectedParking";
import { Parkings } from "../../../../core/domain/type/Parkings";

export const ParkingOwnerBody = () => {
  const [selectedParking, setSelectedParking] = useState<Parkings>();
  const selectParkingHandler = (parking: Parkings) => {
    setSelectedParking(parking);
  };

  return (
    <div>
      <History />
      <div style={{ display: "flex", gap: 10 }}>
        <NewParkingForm />
        <ParkingList selectParkingHandler={selectParkingHandler} />
        <SelectedParking selectedParking={selectedParking} />
      </div>
    </div>
  );
};
