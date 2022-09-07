import { parkingForm } from "../domain/type/parkingForm";

export const postNewParkingUsage = async (usageForm: parkingForm) => {
  return await (
    await fetch("http://localhost:6168/History/NewParkingUsage", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(usageForm),
    })
  ).json();
};
