import { useEffect, useState } from "react";
import { getHistory } from "../../../core/services/getHistory";
import Spinner from "../Spinner";

import "./history.css";

interface HistoryType {
  id: number;
  parkingId: number;
  parkingName: string;
  startDate: string;
  stopDate: string;
  userId: number;
  username: string;
}

export const History = () => {
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
