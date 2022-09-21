import React, { useEffect, useState } from "react";

import { getHistory } from "../../../core/services/getHistory";

import type { HistoryType } from "../../../core/domain/type/HistoryType";
import { postSearchHistory } from "../../../core/services/postSearchHistory";

export const useGetHistory = () => {
  const [history, setHistory] = useState<HistoryType[]>([]);
  const [searchParam, setSearchParam] = useState("");
  const [fetchingStatus, setFetchingStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");

  const fetchHistory = async () => {
    setFetchingStatus("loading");
    try {
      setHistory(await getHistory());
      setFetchingStatus("success");
    } catch (error) {
      setFetchingStatus("error");
    }
  };

  const refreshHandler = () => {
    fetchHistory();
  };

  const searchParamHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchParam(event.target.value);
  };
  const searchActionHandler = async (event: React.FormEvent) => {
    event.preventDefault();
    setFetchingStatus("loading");
    try {
      setHistory(await postSearchHistory(searchParam));

      setFetchingStatus("success");
    } catch (error) {
      setFetchingStatus("error");
    }
  };

  useEffect(() => {
    fetchHistory();
  }, []);

  return {
    history,
    fetchingStatus,
    refreshHandler,
    searchActionHandler,
    searchParamHandler,
  };
};
