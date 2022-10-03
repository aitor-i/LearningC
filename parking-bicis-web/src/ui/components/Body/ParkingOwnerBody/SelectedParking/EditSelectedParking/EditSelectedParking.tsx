import { Parkings } from "../../../../../../core/domain/type/Parkings";
import Spinner from "../../../../Spinner";
import { useEditSelectedParking } from "./useEditSelectedParking";

interface Props {
  selectedParking: Parkings | undefined;
  changeToViewMode: () => void;
}

export const EditSelectedParking = ({
  selectedParking,
  changeToViewMode,
}: Props) => {
  const { editNameHandler, onSaveHandler, newParkingName, loadingStatus } =
    useEditSelectedParking(changeToViewMode, selectedParking!);

  return (
    <form className="parking-data" onSubmit={onSaveHandler}>
      <p>{selectedParking?.id}</p>
      <input
        type="text"
        name="parking-name"
        onChange={editNameHandler}
        value={newParkingName}
      />
      <p>{selectedParking?.username}</p>
      <button>{loadingStatus === "loading" ? <Spinner /> : "Save"}</button>
    </form>
  );
};
