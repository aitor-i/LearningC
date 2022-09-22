import React, { useState } from "react";
import { HistoryType } from "../../../core/domain/type/HistoryType";
import { setSearchedHistory } from "../History/setSearchedHistory";
import "./search-component.css";

interface Props {
  setFetchingStatus: (
    value: React.SetStateAction<"loading" | "success" | "error" | "idle">
  ) => void;
  setHistory: (value: React.SetStateAction<HistoryType[]>) => void;
}

export const SearchComponent = ({ setFetchingStatus, setHistory }: Props) => {
  const [searchParam, setSearchParam] = useState("");

  const searchParamHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchParam(event.target.value);
  };

  const searchActionHandler = async (event: React.FormEvent) => {
    event.preventDefault();
    setSearchedHistory({ searchParam, setFetchingStatus, setHistory });
  };
  return (
    <form className="search-component">
      <input type="text" onChange={searchParamHandler} />
      <button onClick={searchActionHandler}>Search</button>
    </form>
  );
};
