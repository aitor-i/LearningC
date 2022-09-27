import { render, screen } from "@testing-library/react";

import { LoginContextProvider } from "../../../store/loging-ctx";
import { MainLoginPage } from "../MainLoginPage";
import { LoginForm } from "../LoginForm/LoginForm";

const renderMainLoginPage = () => {
  render(
    <LoginContextProvider>
      <MainLoginPage />
    </LoginContextProvider>
  );
};

const renderLoginForm = () => {
  render(
    <LoginContextProvider>
      <LoginForm />
    </LoginContextProvider>
  );
};

describe("Main Login Page", () => {
  it("should render MainLoginPage", () => {
    renderMainLoginPage();
  });

  it("should be login the default action", () => {
    renderMainLoginPage();

    const title = screen.getByRole("heading", {
      name: /login/i,
    });

    expect(title.textContent).toContain("Login");
  });
});

describe("Login form", () => {
  it("should render login from", () => {
    renderLoginForm();
  });
  it("should be a username input", () => {
    renderLoginForm();

    const inputBox = screen.getByRole("textbox", {
      name: /username/i,
    });

    expect(inputBox).toBeDefined();
  });
  it("should be a password input", () => {
    renderLoginForm();

    const inputBox = screen.getByRole("textbox", {
      name: /password/i,
    });

    expect(inputBox).toBeDefined();
  });
});
