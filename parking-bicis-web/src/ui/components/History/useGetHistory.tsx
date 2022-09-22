import React, { useEffect, useState } from "react";

import { getHistory } from "../../../core/services/getHistory";

import type { HistoryType } from "../../../core/domain/type/HistoryType";

export const useGetHistory = () => {
  const [history, setHistory] = useState<HistoryType[]>([]);
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

  useEffect(() => {
    fetchHistory();
  }, []);

  return {
    history,
    fetchingStatus,
    refreshHandler,
    setFetchingStatus,
    setHistory,
  };
};
