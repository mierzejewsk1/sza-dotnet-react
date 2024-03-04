import React, { createContext, useEffect, useState } from "react";
import { UserProfile } from "../models/User";
import axios from "axios";
import { loginAPI, registerAPI } from "../services/AuthService";
import { toast } from "react-toastify";

type UserContextType = {
  user: UserProfile | null;
  token: string | null;
  registerUser: (
    email: string,
    username: string,
    password: string,
    role: string,
    majorId: number
  ) => void;
  loginUser: (email: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

export const UserContext = createContext<UserContextType>(
  {} as UserContextType
);

export const UserProvider = ({ children }: Props) => {
  const [isReady, setIsReady] = useState<boolean>(false);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [token, setToken] = useState<string | null>(null);

  useEffect(() => {
    const user = localStorage.getItem("user");
    const token = localStorage.getItem("token");
    if (user && token) {
      setUser(JSON.parse(user));
      setToken(token);
      axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    }
    setIsReady(true);
  }, []);

  const registerUser = async (
    username: string,
    email: string,
    password: string,
    role: string,
    majorId: number
  ) => {
    try {
      const res = await registerAPI(username, email, password, role, majorId);
      if (res) {
        localStorage.setItem("token", res?.data.token);
        const userObj = {
          userName: res?.data.userName,
          email: res?.data.email,
          role: res?.data.role,
          id: res?.data.id,
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(res?.data.token);
        setUser(userObj);
        toast.success("Pomyślnie zalogowano");
      }
    } catch (e) {
      toast.warning("Nie udało się zarejestrować");
    }
  };

  const loginUser = async (email: string, password: string) => {
    try {
      const res = await loginAPI(email, password);
      if (res) {
        localStorage.setItem("token", res?.data.token);
        const userObj = {
          userName: res?.data.userName,
          email: res?.data.email,
          role: res?.data.role,
          id: res?.data.id,
        };
        localStorage.setItem("user", JSON.stringify(userObj));
        setToken(res?.data.token);
        setUser(userObj);
        toast.success("Pomyślnie zalogowano");
      }
    } catch (e) {
      toast.warning("Nie udało się zalogować");
    }
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const logout = () => {
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    setUser(null);
    setToken(null);
  };

  return (
    <UserContext.Provider
      value={{ user, token, registerUser, loginUser, logout, isLoggedIn }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);
