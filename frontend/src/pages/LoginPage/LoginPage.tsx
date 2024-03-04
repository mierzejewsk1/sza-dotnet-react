import "./LoginPage.css";
import { useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import Logo from "../assets/images/logo3.png";
import { useAuth } from "../../context/AuthContext";

const LoginPage = () => {
  const navigate = useNavigate();
  const email = useRef<HTMLInputElement>();
  const password = useRef<HTMLInputElement>();
  const { loginUser } = useAuth();

  const Login = async () => {
    await loginUser(email.current.value, password.current.value);
    await navigate("/dashboard");
  };

  return (
    <div
      className={`flex justify-center items-center bg-second w-full h-screen`}
    >
      <section
        className={`w-full flex flex-col items-center px-10 sm:w-[500px]`}
      >
        <img
          src={Logo}
          alt="Main page logos"
          className={`h-16 w-26 mb-10`}
        ></img>
        <form
          className={`flex flex-col w-full`}
          onSubmit={(e) => e.preventDefault()}
        >
          <label htmlFor="email" className="font-bold text-white">
            Adres email:
          </label>
          <input
            id="email"
            type="email"
            ref={email}
            className={`px-2 py-1 rounded-md my-2 border border-black bg-gray-300 text-second`}
          ></input>
          <label htmlFor="password" className="font-bold text-white">
            Hasło użytkownika:
          </label>
          <input
            id="password"
            type="password"
            ref={password}
            className={`px-2 py-1 rounded-md my-2 border border-black bg-gray-300`}
          ></input>
          <span className={`self-end text-blue-700`}>Nie pamiętasz hasła?</span>
          <button
            className={`px-5 py-1 font-bold bg-bkg1 text-txt1 border border-gray-800 rounded-md mt-5`}
            onClick={() => {
              Login();
            }}
          >
            Zaloguj się
          </button>
          <span className="mt-5 text-white">
            By signing in you accept the{" "}
            <span className={`text-blue-700`}>
              Terms of Use and acknowledge the Privacy Statement and Cookie
              Policy
            </span>
            .
          </span>
          <span className="text-center mt-10 text-white">
            Nie masz jeszcze konta?{" "}
            <span className={`text-blue-700`}>Zarejestruj się</span>
          </span>
        </form>
      </section>
    </div>
  );
};

export default LoginPage;
