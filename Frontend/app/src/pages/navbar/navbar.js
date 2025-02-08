import { Link, useMatch, useResolvedPath } from "react-router-dom";
import navStyles from "./navbar.module.css";
import {getToken,deleteToken } from "../../utils/storage"
import { jwtDecode } from "jwt-decode";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

export default function Navbar() {
  const history = useNavigate();
  const [token, setToken] = useState(() => {
    return jwtDecode(getToken("token"))
  });
  const handleLogOut = () => {
    deleteToken();
    history("/");
  }
  function CustomLink({ to, children, ...props }) {
    const resolvedPath = useResolvedPath(to);
    const isActive = useMatch({ path: resolvedPath.pathname, end: true });
    
    return (
      <li className={isActive ? "active" : ""}>
        <Link to={to} {...props}>
          {children}
        </Link>
      </li>
    );
  }

  return (
    <div style={{ backgroundColor: "#f1f4f9", color: "#f1f4f9" }}>
      <nav className={navStyles.navbar}>
        <div className={navStyles.title}>
          <button id="logout-button" className={navStyles.buttonn} onClick={handleLogOut}>Logout</button>
        </div>
        <div >
          <h1>BOOKGRAM</h1>
        </div>
        <div className={navStyles.navbarlinks}>
          <ul>
            <li>
              <CustomLink to="/Home" id="home-tab">Home</CustomLink>
            </li>

            <li>
              <CustomLink to="/Feed" id="feed-tab">Feed</CustomLink>
            </li>

            <li>
              <CustomLink to="/Profile" id="profile-tab">Profile</CustomLink>
            </li>
            {token?.role=='Admin' ? <li>
              <CustomLink to="/AdminPage" id="admin-page-tab">AdminPage</CustomLink>
            </li> : null} 
          </ul>
        </div>
      </nav>
    </div>
  );
}