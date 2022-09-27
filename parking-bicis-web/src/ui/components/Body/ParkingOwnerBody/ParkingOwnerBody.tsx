import React from "react";
import History from "../../History";
import NewParkingForm from "../../NewParkingForm";
import { ParkingList } from "../../ParkingList/ParkingList";

export const ParkingOwnerBody = () => {
  return (
    <div>
      <History />
      <div style={{ display: "flex", gap: 10 }}>
        <NewParkingForm />
        <ParkingList />
      </div>
    </div>
  );
};
