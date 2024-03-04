import { Link } from "react-router-dom";
import "../Announcement/Announcement.css";

type AnnouncementProps = {
  Subject: string;
  AppUsername: string;
  Description: string;
  CreatedOn: Date;
};

const Announcement = ({
  Subject,
  AppUsername,
  Description,
  CreatedOn,
}: AnnouncementProps) => {
  return (
    <article
      className={`w-full px-8 py-5 pt-5 flex flex-col mb-3 rounded-sm bg-first`}
    >
      <div className="flex flex-col lg:flex-row  lg:items-center mb-5 w-full">
        <p className="text-[20px] w-[100%] pr-5 lg:w-[60%]">{Subject}</p>
        <p className="text-gray-400 w-[100%] mt-2 lg:mt-0 lg:text-right lg:w-[40%]">
          Autor: {AppUsername}
        </p>
      </div>
      <p className=" overflow-y-hidden text-sm min-[1700px]:text-md">
        {Description}
      </p>
      <div className="flex items-center justify-between mt-5">
        <p className="text-xs">
          Dodane: {`${new Date().toISOString().slice(0, 19).replace("T", " ")}`}
        </p>
        <span className="cursor-pointer bg-third px-3 py-1 rounded-md text-sm hover:bg-fourth transition">
          <Link to="/information" className={`font-normal`}>
            Czytaj dalej
          </Link>
        </span>
      </div>
    </article>
  );
};

export default Announcement;
