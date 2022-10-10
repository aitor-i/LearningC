import { render, screen } from "@testing-library/react";
import { SearchComponent } from "../SearchComponent";

describe("Search component", () => {
  it("should render search component", () => {
    render(<SearchComponent />);
  });

  it("should have a search button", () => {
    render(<SearchComponent />);

    const searchButton = screen.getByRole("button", { name: /search/i });

    expect(searchButton.textContent).toMatch(/search/i);
  });
});
