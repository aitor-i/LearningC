import HistoryContainer from "./HistoryContainer";
import SearchComponent from "../SearchCompnent";

import { useGetHistory } from "./useGetHistory";

import "./history.css";
import ErrorBoundary from "../ErrorBoundary/ErrorBoundary";

export const History = () => {
  const {
    history,
    fetchingStatus,
    refreshHandler,
    setFetchingStatus,
    setHistory,
  } = useGetHistory();
  return (
    <div>
      <h2>Parking usage history</h2>
      <ErrorBoundary>
        <SearchComponent
          setFetchingStatus={setFetchingStatus}
          setHistory={setHistory}
        />
      </ErrorBoundary>
      <ErrorBoundary>
        <HistoryContainer fetchingStatus={fetchingStatus} history={history} />
      </ErrorBoundary>
      <button onClick={refreshHandler}>Refresh</button>
    </div>
  );
};
