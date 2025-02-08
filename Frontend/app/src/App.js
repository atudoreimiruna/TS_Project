import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import './pages/authentication/Authentication.css';
import { Login } from "./pages/authentication/Login";
import { RecoverPassword } from "./pages/authentication/RecoverPassword";
import { Register } from "./pages/authentication/Register";
import Profile from "./pages/profile/Profile";
import AdminPage from "./pages/adminPage/AdminPage";
import Feed from "./pages/feed/Feed";
import Home from "./pages/home/Home";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route exact path="" element={<Login />} />
          <Route exact path="/Authentication/RecoverPassword" element={<RecoverPassword />} />
          <Route exact path="/Authentication/Register" element={<Register />} />
          <Route exact path="/Profile" element={<Profile />} />
          <Route exact path="/AdminPage" element={<AdminPage/>}/>
          <Route exact path="/Feed" element={<Feed />} />
          <Route exact path="/Home" element={<Home />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
