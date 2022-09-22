import { HistoryType } from "../../../core/domain/type/HistoryType";
import { postSearchHistory } from "../../../core/services/postSearchHistory";

interface Params {
  setFetchingStatus: (
    value: React.SetStateAction<"loading" | "success" | "error" | "idle">
  ) => void;
  setHistory: (value: React.SetStateAction<HistoryType[]>) => void;
  searchParam: string;
}

export const setSearchedHistory = async ({
  searchParam,
  setFetchingStatus,
  setHistory,
}: Params) => {
  setFetchingStatus("loading");
  try {
    setHistory(await postSearchHistory(searchParam));

    setFetchingStatus("success");
  } catch (error) {
    setFetchingStatus("error");
  }
};
