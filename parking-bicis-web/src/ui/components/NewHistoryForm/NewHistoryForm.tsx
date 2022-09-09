import React, { useEffect, useState, useRef, useContext } from "react";
import { parkingForm } from "../../../core/domain/type/parkingForm";
import { getParkings } from "../../../core/services/getParkings";
import { postNewParkingUsage } from "../../../core/services/postNewParkingUsage";
import { LoginContext } from "../../store/loging-ctx";

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
  const [fetchingStatus, setFetchingStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");

  const { isLogged } = useContext(LoginContext);

  const registerParkingForm = useRef<HTMLFormElement>(null);

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

  const selectParkingHandler = (
    event: React.ChangeEvent<HTMLSelectElement>
  ) => {
    setParkingId(+event.target.value);
  };

  const bookParkingsHandler = async (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    event.preventDefault();

    try {
      const newRegisterForm: parkingForm = {
        parkingId,
        startDate: enterTime,
        stopDate: exitTime,
        userId: 1,
      };
      const response = await postNewParkingUsage(newRegisterForm);
      alert(`Your registration id is ${response}`);
    } catch (error) {
      alert(error);
    } finally {
      if (registerParkingForm.current) {
        registerParkingForm.current.reset();
      }
    }
  };

  const enterTimeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEnterTime(event.target.value);
  };

  const exitTimeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setExitTime(event.target.value);
  };

  return (
    <>
      {isLogged ? (
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
      ) : (
        <p>You must be logged to use the parking</p>
      )}
    </>
  );
};
