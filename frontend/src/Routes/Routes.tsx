import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";
import App from "../App";
import LandingPage from "../pages/LandingPage/LandingPage";
import LoginPage from "../pages/LoginPage/LoginPage";
import Administrator from "../pages/Dashboards/Administrator";
import Faults from "../pages/Faults/Faults";
import RoomSelect from "../pages/RoomSelect/RoomSelect";
import { useAuth } from "../context/AuthContext";
import { USER_TYPES } from "../config/Enum";
import Inhabitant from "../pages/Dashboards/Inhabitant";
import Conservator from "../pages/Dashboards/Conservator";
import Recepcionist from "../pages/Dashboards/Recepcionist";

export const Router = () => {
  const { user, isLoggedIn } = useAuth();

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />}>
          <Route path="/" element={<LandingPage />} />
        </Route>
        <Route
          path="/login"
          element={!user ? <LoginPage /> : <Navigate to="/dashboard" />}
        />
        {isLoggedIn ? (
          <>
            <Route
              path="/dashboard"
              element={
                user && user.role === USER_TYPES.ADMIN ? (
                  <Administrator />
                ) : user && user.role === USER_TYPES.INHABITANT ? (
                  <Inhabitant />
                ) : user && user.role === USER_TYPES.CONSERVATOR ? (
                  <Conservator />
                ) : user && user.role === USER_TYPES.RECEPCIONIST ? (
                  <Recepcionist />
                ) : (
                  <Navigate to="/login" />
                )
              }
            />
            <Route
              path="/faults"
              element={user ? <Faults /> : <Navigate to="/dashboard" />}
            />
            <Route
              path="/rooms"
              element={user ? <RoomSelect /> : <Navigate to="/dashboard" />}
            />
          </>
        ) : null}
      </Routes>
    </BrowserRouter>
  );
};
