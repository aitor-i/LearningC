import { render, screen } from "@testing-library/react";

import { LoginContextProvider } from "../../../store/loging-ctx";
import { MainLoginPage } from "../MainLoginPage";
import { LoginForm } from "../LoginForm/LoginForm";
import RegisterForm from "../RegisterForm";

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

const renderRegisterForm = () => {
  render(
    <LoginContextProvider>
      <RegisterForm />
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

    const inputBox = screen.getByLabelText(/password/i);

    expect(inputBox.type).toBe("password");
  });
});

describe("Register from", () => {
  it("should render register form", () => {
    renderRegisterForm();
  });
  it("should should be name input", () => {
    renderRegisterForm();

    const input = screen.getByRole("textbox", {
      name: /username/i,
    });

    expect(input).toBeDefined();
  });
  it("should be password input", () => {
    renderRegisterForm();

    const input = screen.getByLabelText(/password/i);

    expect(input.type).toBe("password");
  });
  it("should be type select input", () => {
    renderRegisterForm();

    const input = screen.getByRole("combobox");

    expect(input.type).toBe("select-one");
  });

  it("should be bike user option", () => {
    renderRegisterForm();

    //const input = screen.getByRole("combobox");
    //const input = screen.getByText(/bike/i);
    const option = screen.getByRole("option", { name: /bike/i });

    expect(option.textContent).toBe("Bike user");
  });

  it("should be parking owner option", () => {
    renderRegisterForm();

    const option = screen.getAllByRole("option");

    expect(option[1].textContent).toBe("Parking owner");
  });
});
