import { useEffect, useState } from "react";
import { getHistory } from "../../../core/services/getHistory";

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

  const fetchHistory = async () => {
    setHistory(await getHistory());
  };

  useEffect(() => {
    fetchHistory();
  }, []);

  return (
    <div>
      <h2>Parking usage history</h2>
      <div className="histories-container">
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
      </div>
    </div>
  );
};
