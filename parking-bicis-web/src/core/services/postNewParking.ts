import { NewParkingForm } from "../domain/type/NewParkingForm";

export const postNewParking = async (newParking: NewParkingForm) => {
  const response = fetch(
    `${process.env.REACT_APP_API_URL}/Parking/NewPArking`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newParking),
    }
  );

  if (!(await response).ok) throw new Error((await response).toString());
  return (await response).json();
};
