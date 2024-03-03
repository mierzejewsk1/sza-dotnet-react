import axios from "axios";
import { HOST_ADDRESS } from "../config/Enum";
import { InhabitantUserInfo } from "../models/User";

export const userGetAPI = async (id: string) => {
  try {
    const data = await axios.get<InhabitantUserInfo>(
      `${HOST_ADDRESS}/api/account/${id}`
    );
    return data;
  } catch (error) {
    console.log(error);
  }
};
