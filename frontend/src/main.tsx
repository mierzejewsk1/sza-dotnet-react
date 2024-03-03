import ReactDOM from "react-dom/client";
import "./index.css";
import { ThemeProvider } from "./context/ThemeProvider.tsx";
import { Router } from "./Routes/Routes.tsx";
import { UserProvider } from "./context/AuthContext";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <ThemeProvider>
    <UserProvider>
      <Router />
    </UserProvider>
  </ThemeProvider>
);
