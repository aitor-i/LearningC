import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { faker } from "@faker-js/faker";

import { LoginContextProvider } from "../../../store/loging-ctx";
import { MainLoginPage } from "../MainLoginPage";
import { LoginForm } from "../LoginForm/LoginForm";
import RegisterForm from "../RegisterForm";

import { rest } from "msw";
import { setupServer } from "msw/node";

import ReactDOM from "react-dom";

const server = setupServer(
  rest.post("http://localhost:8460/Users/login", async (req, res, ctx) => {
    const loginResponse = {
      usersId: "",
      isLogged: false,
      userType: "",
      username: req.username,
      password: null,
    };
    return res(ctx.json(loginResponse));
  })
);

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
  beforeAll(() => {
    ReactDOM.createPortal = jest.fn((element, node) => {
      return element;
    });
    server.listen();
  });

  afterAll(() => server.close());

  afterEach(() => {
    ReactDOM.createPortal.mockClear();
  });
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

  it("should collect username and password", async () => {
    renderLoginForm();

    const username = faker.name.fullName();
    const password = faker.internet.password();

    const usernameInput = screen.getByLabelText(/password/i);
    const passwordInput = screen.getByLabelText(/username/i);
    userEvent.type(usernameInput, username);
    expect(usernameInput.value).toBe(username);

    userEvent.type(passwordInput, password);
    expect(passwordInput.value).toBe(password);
    const submit = screen.getByRole("button", { name: /submit/i });
    userEvent.click(submit);
    const spinner = await screen.findByTestId("spinner");

    expect(spinner.className).toBe("spinner");
  });
  it("should show error login on fake credentials", async () => {
    renderLoginForm();

    ReactDOM.createPortal = jest.fn((element, node) => {
      return element;
    });

    const username = faker.name.fullName();
    const password = faker.internet.password();

    const usernameInput = screen.getByLabelText(/password/i);
    const passwordInput = screen.getByLabelText(/username/i);
    userEvent.type(usernameInput, username);
    userEvent.type(passwordInput, password);

    const submit = screen.getByRole("button", { name: /submit/i });
    userEvent.click(submit);

    const errorToast = await screen.findByTestId("error-toast");
    const errorMessage = String(errorToast.textContent);

    // expect(errorToast.innerText).toMatchInlineSnapshot("Error");
    expect(errorMessage).toMatch(/error/i);
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
