import { HOST_ADDRESS } from "../config/Enum";
import axios from "axios";
import { AnnouncementGet } from "../models/Announcement";

export const announcementGetAPI = async () => {
  try {
    const data = await axios.get<AnnouncementGet[]>(
      `${HOST_ADDRESS}/api/announcement`
    );

    return data;
  } catch (error) {
    console.log(error);
  }
};

export const announcementPostAPI = async (
  subject: string,
  description: string
) => {
  try {
    const data = await axios.post<AnnouncementGet>(
      `${HOST_ADDRESS}/api/announcement`,
      { subject: subject, descripton: description }
    );

    return data;
  } catch (e) {
    console.log(e);
  }
};

export const announcementGetByIdAPI = async (id: number) => {
  try {
    const data = await axios.post<AnnouncementGet>(
      `${HOST_ADDRESS}/api/announcement/${id}`
    );
    return data;
  } catch (e) {
    console.log(e);
  }
};

export const announcementDeleteAPI = async (id: number) => {
  try {
    const data = await axios.delete<AnnouncementGet>(
      `${HOST_ADDRESS}/api/announcement/${id}`
    );
    return data;
  } catch (e) {
    console.log(e);
  }
};

export const announcementPatchAPI = async (
  id: number,
  subject: string,
  description: string
) => {
  try {
    const data = await axios.patch<AnnouncementGet>(
      `${HOST_ADDRESS}/api/announcement/${id}`,
      {
        subject: subject,
        descripton: description,
      }
    );
    return data;
  } catch (e) {
    console.log(e);
  }
};
