export const postSearchHistory = async (searchParam: string) => {
  const endpoint = new URL(`${process.env.REACT_APP_API_URL}/History/search`);
  endpoint.searchParams.append("expression", searchParam);
  const response = fetch(endpoint, {
    method: "POST",
  });

  if (!(await response).ok) throw new Error((await response).toString());
  return (await response).json();
};
