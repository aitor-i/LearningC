export const getParkings = async () => {
  return await (
    await fetch("http://localhost:6168/Parking/AllParkings")
  ).json();
};
