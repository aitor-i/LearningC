export const postSearchHistory = async (searchParam: string) => {
  const response = fetch(
    `http://localhost:6168/History/search?expresion=${searchParam}`,
    {
      method: "POST",
    }
  );

  if (!(await response).ok) throw new Error((await response).toString());
  return (await response).json();
};
