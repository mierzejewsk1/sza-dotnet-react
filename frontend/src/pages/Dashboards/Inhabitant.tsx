import { useState, useEffect } from "react";
import QRCode from "react-qr-code";
import DashboardLayout from "../../layout/DashboardLayout/DashboardLayout";
import Profile from "../../assets/images/lack_of_profile.png";
import { useAuth } from "../../context/AuthContext";
import Announcement from "../../components/Announcement/Announcement";
import { AnnouncementGet } from "../../models/Announcement";
import { announcementGetAPI } from "../../services/AnnouncementService";
import { userGetAPI } from "../../services/UserService";
import { InhabitantUserInfo } from "../../models/User";

const Inhabitant = () => {
  const [announcements, setAnnouncements] = useState<AnnouncementGet[]>([]);
  const [
    loggedUserData,
    setLoggedUserData,
  ] = useState<InhabitantUserInfo | null>(null);

  const { user } = useAuth();

  useEffect(() => {
    const getAnnouncements = async () => {
      try {
        const res = await announcementGetAPI();
        setAnnouncements(res?.data);
      } catch (e) {
        console.log(e);
      }
    };

    const getUserInfo = async () => {
      try {
        const res = await userGetAPI(user.id);
        setLoggedUserData(res?.data);
      } catch (e) {
        console.log(e);
      }
    };
    getAnnouncements();
    getUserInfo();
  }, []);

  return (
    <DashboardLayout pageName="Mieszkaniec">
      <article className="h-full w-full flex justify-center bg-second">
        <section className="w-full px-10 min-w-[400px] sm:max-w-[400px] h-full pt-5 pb-20 overflow-y-scroll my-2 rounded-sm">
          <p className="text-[30px] mb-5">Karta mieszkańca</p>
          <div className="flex justify-center flex-col text-lg p-5 rounded-sm">
            <div className="flex justify-center">
              <img src={Profile} className="w-40 pb-5"></img>
            </div>
            <section className="h-20">
              <p className="text-gray-500">Imie i nazwisko:</p>
              {<p>{loggedUserData && loggedUserData.userName}</p>}
            </section>
            <div className="flex h-20">
              <section className="w-full">
                <p className="w-full text-gray-500">Wydział:</p>
                <p className="w-full">
                  {loggedUserData && loggedUserData.departmentName}
                </p>
              </section>
              <section className="w-full pl-10">
                <p className="w-full text-gray-500">Nr pokoju:</p>
                <p className="w-full">210</p>
              </section>
            </div>
            <section className="h-20">
              <p className="text-gray-500">Kierunek</p>
              <p>{loggedUserData && loggedUserData.majorName}</p>
            </section>
            <section className="w-full flex justify-center mt-2 ">
              <QRCode
                className="p-2 bg-white"
                value={`http://localhost:5173/qr-profile-info/?userId=${
                  user && user.id
                }`}
                xlinkTitle={`Szczegółowe informacje o użytkowniku ${
                  user && user.id
                }`}
                bgColor="white"
                fgColor="black"
                size={200}
              />
            </section>
          </div>
        </section>
        <section className="w-full hidden 2xl:flex min-[2000px]:w-[60%] flex-col px-10 overflow-y-scroll my-2 pb-20 border-l border-gray-700">
          <p className={`pt-5 pb-5 text-[30px] self-start p-0`}>Ogłoszenia</p>
          {announcements &&
            announcements.map((item, index) => (
              <Announcement
                key={index}
                Subject={item.subject}
                AppUsername={item.appUsername}
                Description={item.descripton}
                CreatedOn={item.createdOn}
              />
            ))}
        </section>
      </article>
    </DashboardLayout>
  );
};

export default Inhabitant;
