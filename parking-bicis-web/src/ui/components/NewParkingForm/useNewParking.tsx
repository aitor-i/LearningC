import { useContext, useState } from "react";
import { postNewParking } from "../../../core/services/postNewParking";
import { LoginContext } from "../../store/loging-ctx";

export const useNewParking = () => {
  const [parkingName, setParkingName] = useState("");
  const [loadingState, setLoadingState] = useState<
    "idle" | "loading" | "success" | "error"
  >("idle");
  const { user } = useContext(LoginContext);
  const parkingNameHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setParkingName(event.target.value);
  };

  const publishHandler = async (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) => {
    event.preventDefault();
    try {
      setLoadingState("loading");
      const res: Response = await postNewParking({
        usersId: user.usersId,
        parkinName: parkingName,
      });
      if (!res.ok) {
        const error = new Error();
        error.message = res.toString();
        throw error;
      }

      alert(`Parking published, parking id: ${res}`);
      setLoadingState("success");
    } catch (error) {
      alert(error);
      setLoadingState("error");
    }
  };
  return { loadingState, publishHandler, parkingNameHandler };
};
