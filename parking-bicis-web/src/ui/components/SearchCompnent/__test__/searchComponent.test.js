import { fireEvent, render, screen } from "@testing-library/react";
import { faker } from "@faker-js/faker";

import { SearchComponent } from "../SearchComponent";
import userEvent from "@testing-library/user-event";

describe("Search component", () => {
  it("should render search component", () => {
    render(<SearchComponent />);
  });

  it("should have a search button", () => {
    render(<SearchComponent />);

    const searchButton = screen.getByRole("button", { name: /search/i });

    expect(searchButton.textContent).toMatch(/search/i);
  });

  it("should feel input item", () => {
    render(<SearchComponent />);

    const randomName = faker.name.firstName();
    const input = screen.getByRole("textbox");

    userEvent.type(input, randomName);

    expect(input.value).toBe(randomName);
  });
});
