import { render, screen } from "@testing-library/react";

import App from "../App";

describe("App component", () => {
  it("should render App component", () => {
    render(<App />);
  });
  it("should show 'Parking' title", () => {
    render(<App />);

    const title = screen.getByRole("heading", {
      name: /parking/i,
    });

    expect(title.textContent).toContain("Parking");
  });
});
