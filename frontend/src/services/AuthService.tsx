import { UserProfileToken } from "../models/User";
import { HOST_ADDRESS } from "../config/Enum";
import axios from "axios";

export const loginAPI = async (email: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(
      `${HOST_ADDRESS}/api/account/login`,
      {
        email: email,
        password: password,
      }
    );
    console.log(data);
    return data;
  } catch (error) {
    console.log(error);
  }
};

export const registerAPI = async (
  username: string,
  email: string,
  password: string,
  role: string | null,
  majorId: number | null
) => {
  try {
    const data = await axios.post<UserProfileToken>(
      `${HOST_ADDRESS}/api/account/register`,
      {
        username: username,
        email: email,
        password: password,
        role: role,
        majorId: majorId,
      }
    );
    return data;
  } catch (error) {
    console.log(error);
  }
};
