import { render, screen } from "@testing-library/react";

import { History } from "../History";

const renderHistory = () => {
  render(<History />);
};

describe("History component", () => {
  it("should render history component", () => {
    renderHistory();
  });

  it("should be 'Parking usage history'", () => {
    renderHistory();

    const title = screen.getByRole("heading");

    expect(title.textContent).toBe("Parking usage history");
  });

  it("should be search component", () => {
    renderHistory();

    const form = screen.getByLabelText(/search/i);

    expect(form).toBeDefined();
  });
});
