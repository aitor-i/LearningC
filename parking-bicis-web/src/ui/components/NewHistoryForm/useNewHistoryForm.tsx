import React, { useContext, useEffect, useRef, useState } from "react";
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

export const useNewHistoryForm = () => {
  const [parkings, setParkings] = useState<Parkings[]>([]);
  const [parkingId, setParkingId] = useState<number>(0);
  const [enterTime, setEnterTime] = useState("");
  const [exitTime, setExitTime] = useState("");
  const [fetchingStatus, setFetchingStatus] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");

  const { isLogged, user } = useContext(LoginContext);

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
        userId: user.usersId,
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

  return {
    parkings,
    exitTimeHandler,
    enterTimeHandler,
    bookParkingsHandler,
    selectParkingHandler,
    isLogged,
    fetchParkings,
    fetchingStatus,
    registerParkingForm,
  };
};
