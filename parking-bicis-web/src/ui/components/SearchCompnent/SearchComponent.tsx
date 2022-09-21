import React from "react";
import "./search-component.css";

interface Props {
  searchParamHandler: (event: React.ChangeEvent<HTMLInputElement>) => void;
  searchActionHandler: (event: React.FormEvent) => void;
}

export const SearchComponent = ({
  searchActionHandler,
  searchParamHandler,
}: Props) => {
  return (
    <form className="search-component">
      <input type="text" onChange={searchParamHandler} />
      <button onClick={searchActionHandler}>Search</button>
    </form>
  );
};
