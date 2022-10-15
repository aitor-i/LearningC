import { render } from "@testing-library/react";
import { NewParkingForm } from "../NewParkingForm";

describe("New Parking", () => {
  it("should render new parking component", () => {
    render(<NewParkingForm />);
  });
});
