import Spinner from "../Spinner";

import { useGetHistory } from "./useGetHistory";

import "./history.css";

import type { HistoryType } from "../../../core/domain/type/HistoryType";

export const History = () => {
  const { history, fetchingStatus, refreshHandler } = useGetHistory();

  return (
    <div>
      <h2>Parking usage history</h2>
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
            {history.map((register, index) => (
              <p
                className="history-element"
                key={register.id}
                style={index % 2 === 1 ? { backgroundColor: "lightgray" } : {}}
              >
                <span>{register.id}</span>
                <span>{register.parkingName}</span>
                <span>{register.username}</span>
                <span>{register.startDate}</span>
                <span>{register.stopDate}</span>
              </p>
            ))}
          </>
        )}
      </div>
      <button onClick={refreshHandler}>Refresh</button>
    </div>
  );
};
