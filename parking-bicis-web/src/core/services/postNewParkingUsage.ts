import { parkingForm } from "../domain/type/parkingForm";

export const postNewParkingUsage = async (usageForm: parkingForm) => {
  return await (
    await fetch(`${process.env.REACT_APP_API_URL}/History/NewParkingUsage`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(usageForm),
    })
  ).json();
};
