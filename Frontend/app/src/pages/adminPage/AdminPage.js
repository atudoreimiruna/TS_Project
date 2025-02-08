import React from "react";
import Navbar from "../navbar/navbar";
import { useState } from "react";
import { _delete, _get, _post } from "../../utils/api";
import { useEffect } from "react";
import { getToken } from "../../utils/storage";
import { jwtDecode } from "jwt-decode";
import "./AdminPage.css";

const AdminPage = () => {
    const [title, setTitle] = useState();
    const [description, setDescription] = useState();
    const [usersList, setUsersList] = useState([]);
    const [token, setToken] = useState([]);

    const handleSubmit = (e) => {
        
        e.preventDefault();

        _post("https://localhost:44335/api/Challenges/CreateChallenge", {
            title:title,
            description:description
        }).then((response) => {
            if (response) {
                console.log("challenge-response: " , response);
            }
        }).catch((err) => {
            console.log("challenge-error:", err);
        }) 
    } 

    const getAllUsers = () => {
        _get("https://localhost:44335/api/User/GetAllUsers").then((response) => {
            if (response) {
                console.log("users-response: " , response);
                setUsersList(response.data);
            }
        }).catch((err) => {
            console.log("users-error",err)
        }) 
    }

    const handleDelete = (arg) => {
        _delete(`https://localhost:44335/api/User/DeleteUserBy${arg}`).then((response) => {
                if("delete-user-response", response){
                    getAllUsers();
                }
            }).catch((err) => {
                console.log("delete-user-error",err)
            })
    }

    useEffect(() => {
        getAllUsers();
        if (getToken()) setToken(jwtDecode(getToken()));
      }, []);

    if (token && token?.role === "Admin") {
        return(
            <div>
                <Navbar></Navbar>
                <form className="login-form" onSubmit={handleSubmit}>

                            <h1 className="welcome-text">Create a new challenge!</h1>
                            
                            <label htmlFor="title">Title:</label>
                            <input id="new-challenge-title" className="input-login" value = {title} onChange={(e) => setTitle(e.target.value)} type="text" placeholder="title"  />

                            <label htmlFor="description">Description:</label>
                            <input id="new-challenge-description" className="input-login" value = {description} onChange={(e) => setDescription(e.target.value)}type="text" placeholder="description"   />
                            
                            <button id="create-button" className="create-btn" type="submit"><b>Create</b></button>
                </form>
                <h1 className="welcome-text">User Accounts</h1>

                <table className="tablee">
                    <thead>
                        <tr className="columnn">
                            <th>Id</th>
                            <th>Username</th>
                            <th>Id</th>
                            <th>Delete</th>

                        </tr>
                    </thead>
                    <tbody>
                        {usersList.map((val,key) => (
                            <tr className="users">
                                <td>{val.id}</td>
                                <td>{val.userName}</td>
                                <td>{val.email}</td>
                                <td>
                                    <button onClick={() => handleDelete(val.id)}>
                                        Delete user
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    } else {
        return (
            <h2>Forbidden</h2>
        );
    }
};

export default AdminPage;