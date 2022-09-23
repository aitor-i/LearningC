export const postSearchHistory = async (searchParam: string) => {
  const response = fetch(
    `${process.env.REACT_APP_API_URL}/History/search?expression=${searchParam}`,
    {
      method: "POST",
    }
  );

  if (!(await response).ok) throw new Error((await response).toString());
  return (await response).json();
};
