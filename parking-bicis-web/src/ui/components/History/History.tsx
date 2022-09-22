import Spinner from "../Spinner";

import { useGetHistory } from "./useGetHistory";

import "./history.css";
import SearchComponent from "../SearchCompnent";
import HistoryItem from "./HistoryItem";
import { memo } from "react";

export const History = () => {
  const {
    history,
    fetchingStatus,
    refreshHandler,
    searchActionHandler,
    searchParamHandler,
  } = useGetHistory();
  return (
    <div>
      <h2>Parking usage history</h2>
      <SearchComponent
        searchActionHandler={searchActionHandler}
        searchParamHandler={searchParamHandler}
      />
      <div className="histories-container">
        {fetchingStatus === "loading" ? (
          <Spinner />
        ) : (
          <>
            <p className="history-element history-title">
              {" "}
              <span>Id</span>
              <span>ParkingName</span>
              <span>Username</span>
              <span>StartDate</span>
              <span>StopDate</span>
            </p>
            {history.map((register, index) => {
              const { id, parkingName, startDate, stopDate, username } =
                register;
              const isHighlight = index % 2 === 1;
              return (
                <HistoryItem
                  id={id}
                  isHighlight={isHighlight}
                  startDate={startDate}
                  stopDate={stopDate}
                  parkingName={parkingName}
                  username={username}
                  key={id}
                />
              );
            })}
          </>
        )}
      </div>
      <button onClick={refreshHandler}>Refresh</button>
    </div>
  );
};
