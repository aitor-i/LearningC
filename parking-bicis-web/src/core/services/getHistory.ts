export const getHistory = async () => {
  return await (
    await fetch(`${process.env.REACT_APP_API_URL}/History/AllHistory`)
  ).json();
};
