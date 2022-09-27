import { render, screen } from "@testing-library/react";

import { Header } from "../Header";

describe("Header", () => {
  it("should render header", () => {
    render(<Header />);
  });

  it("should appear 'Parking'", () => {
    render(<Header />);

    const title = screen.getByRole("heading", {
      name: /parking/i,
    });

    expect(title.textContent).toContain("Parking");
  });
});
