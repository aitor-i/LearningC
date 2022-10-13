import { render, screen } from "@testing-library/react";
import { History } from "../History";

describe("History component", () => {
  it("should render history component ", () => {
    render(<History />);
  });

  it("should show refresh button", () => {
    render(<History />);

    const button = screen.getByRole("button", { name: /refresh/i });

    expect(button.textContent).toBe("Refresh");
  });
});
