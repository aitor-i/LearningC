import { NewParkingForm } from "../domain/type/NewParkingForm";

export const postNewParking = async (newParking: NewParkingForm) => {
  const response: Promise<Response> = fetch(
    `${process.env.REACT_APP_API_URL}/Parking/NewPArking`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newParking),
    }
  );

  // if (!(await response).ok) {
  //   const error = new Error();
  //   error.message =  response.toString();
  //   throw error;
  // }
  return (await response).json();
};
