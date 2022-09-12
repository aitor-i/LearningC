import { useNewHistoryForm } from "./useNewHistoryForm";

import "./new-history.css";

export const NewHistoryForm = () => {
  const {
    parkings,
    exitTimeHandler,
    enterTimeHandler,
    bookParkingsHandler,
    selectParkingHandler,
    isLogged,
    registerParkingForm,
  } = useNewHistoryForm();

  return (
    <>
      {isLogged ? (
        <form className="new-history-form" ref={registerParkingForm}>
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
