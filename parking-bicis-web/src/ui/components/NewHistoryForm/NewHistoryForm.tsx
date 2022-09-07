import React, { useEffect, useState, useRef } from "react";
import { parkingForm } from "../../../core/domain/type/parkingForm";
import { getParkings } from "../../../core/services/getParkings";
import { postNewParkingUsage } from "../../../core/services/postNewParkingUsage";

interface Parkings {
  id: number;
  parkinName: string;
  useId: number;
  username: string;
}

export const NewHistoryForm = () => {
  const [parkings, setParkings] = useState<Parkings[]>([]);
  const [parkingId, setParkingId] = useState<number>(0);
  const [enterTime, setEnterTime] = useState("");
  const [exitTime, setExitTime] = useState("");
  const registerParkingForm = useRef(null);

  const fetchParkings = async () => {
    setParkings(await getParkings());
  };

  useEffect(() => {
    fetchParkings();
  }, []);

  const selectParkingHandler = (
    event: React.ChangeEvent<HTMLSelectElement>
  ) => {
    setParkingId(+event.target.value);
  };

  const bookParkingsHandler = async (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    event.preventDefault();
    console.log("enterTime", enterTime);
    console.log("parkingId", parkingId);
    console.log("exitTime", exitTime);
    const newRegisterForm: parkingForm = {
      parkingId,
      startDate: enterTime,
      stopDate: enterTime,
      userId: 1,
    };
    const response = await postNewParkingUsage(newRegisterForm);
    console.log("response", response);
  };

  const enterTimeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEnterTime(event.target.value);
  };

  const exitTimeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setExitTime(event.target.value);
  };

  return (
    <form ref={registerParkingForm}>
      <h2>Use parking</h2>
      <label htmlFor="">Parking name</label>
      <select
        onChange={selectParkingHandler}
        name="pname"
        id="pname"
        placeholder="Central parking"
      >
        <option key={"a"} value={0}>
          Select a parking
        </option>
        {parkings.map((parking) => {
          return (
            <option key={parking.id} value={parking.id}>
              {parking.parkinName}
            </option>
          );
        })}
      </select>
      <label htmlFor="enter-time">Enter time</label>
      <input type="time" id="enter-time" onChange={enterTimeHandler} />

      <label htmlFor="exit-time">Exit time</label>
      <input type="time" id="exit-time" onChange={exitTimeHandler} />

      <button onClick={bookParkingsHandler}>Book it</button>
    </form>
  );
};
