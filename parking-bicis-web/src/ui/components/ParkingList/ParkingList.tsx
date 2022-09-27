import React, { useEffect, useState } from "react";
import { Parkings } from "../../../core/domain/type/Parkings";
import { getParkings } from "../../../core/services/getParkings";
import Spinner from "../Spinner";

export const ParkingList = () => {
  const [parkings, setParkings] = useState<Parkings[]>([]);
  const [fetchingStatus, setFetchingStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");
  const fetchParkings = async () => {
    setFetchingStatus("loading");
    try {
      setParkings(await getParkings());
      setFetchingStatus("success");
    } catch (error) {
      setFetchingStatus("error");
    }
  };

  useEffect(() => {
    fetchParkings();
  }, []);

  return (
    <div>
      {fetchingStatus !== "loading" && fetchingStatus === "success" ? (
        parkings.map((parkin) => <p>{parkin.parkinName}</p>)
      ) : (
        <Spinner />
      )}
    </div>
  );
};
