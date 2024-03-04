export type UserProfileToken = {
  id: string;
  userName: string;
  email: string;
  token: string;
  role: string;
};

export type UserProfile = {
  userName: string;
  email: string;
  role: string;
  id: string;
};

export type InhabitantUserInfo = {
  userName: string;
  email: string;
  role: string;
  departmentName: string;
  majorName: string;
};
