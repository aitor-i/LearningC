import React, { useState } from "react";
import { Parkings } from "../../../../../../core/domain/type/Parkings";
import { putChangeParkingName } from "../../../../../../core/services/putChangeParkingName";

export const useEditSelectedParking = (
  changeToViewMode: () => void,
  selectedParking: Parkings
) => {
  const [loadingStatus, setLoadingStatus] = useState<
    "loading" | "success" | "error" | "idle"
  >("idle");
  const [newParkingName, setNewParkingName] = useState(
    selectedParking?.parkinName
  );
  const editNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewParkingName(event.target.value);
  };

  const changeParkingName = async (parking: Parkings, newName: string) => {
    if (loadingStatus === "loading") return;
    try {
      const newParking: Parkings = { ...parking, parkinName: newName };
      setLoadingStatus("loading");
      const response = await putChangeParkingName(newParking);
      alert(`Parking name changed successfully! ${response}`);
      changeToViewMode();
      setLoadingStatus("success");
    } catch (error) {
      alert(`Error changing parking name, error:${error}`);
      setLoadingStatus("error");
    }
  };

  const onSaveHandler = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    changeParkingName(selectedParking!, newParkingName!);
  };
  return { editNameHandler, onSaveHandler, newParkingName, loadingStatus };
};
