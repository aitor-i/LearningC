export const getHistory = async () => {
  return await (await fetch("http://localhost:6168/History/AllHistory")).json();
};
