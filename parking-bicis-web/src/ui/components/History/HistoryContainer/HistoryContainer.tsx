import { HistoryType } from "../../../../core/domain/type/HistoryType";
import Spinner from "../../Spinner";
import HistoryItem from "../HistoryItem";

interface Props {
  history: HistoryType[];
  fetchingStatus: "loading" | "idle" | "success" | "error";
}

export const HistoryContainer = ({ history, fetchingStatus }: Props) => {
  return (
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
            const { id, parkingName, startDate, stopDate, username } = register;
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
  );
};
