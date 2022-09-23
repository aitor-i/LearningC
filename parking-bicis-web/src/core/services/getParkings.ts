export const getParkings = async () => {
  return await (
    await fetch(`${process.env.REACT_APP_API_URL}/Parking/AllParkings`)
  ).json();
};
