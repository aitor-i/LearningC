import React from "react";

interface Props {
  id: number;
  parkingName: string;
  username: string;
  startDate: string;
  stopDate: string;
  isHighlight: boolean;
}

export const HistoryItem = ({
  id,
  parkingName,
  startDate,
  stopDate,
  username,
  isHighlight,
}: Props) => {
  return (
    <div className={`history-element ${isHighlight && "highlight"} `} key={id}>
      <span>{id}</span>
      <span>{parkingName}</span>
      <span>{username}</span>
      <span>{startDate}</span>
      <span>{stopDate}</span>
    </div>
  );
};
