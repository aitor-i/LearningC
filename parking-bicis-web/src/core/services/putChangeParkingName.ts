import { Parkings } from "../domain/type/Parkings";

export const putChangeParkingName = async (newParking: Parkings) => {
  const endpoint = new URL(
    `${process.env.REACT_APP_API_URL}/Parking/ChangeParkingName`
  );
  const response = fetch(endpoint, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newParking),
  });

  if (!(await response).ok) throw new Error((await response).toString());
  return (await response).json();
};
