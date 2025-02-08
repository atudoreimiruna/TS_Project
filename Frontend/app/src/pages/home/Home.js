import React, { useEffect } from "react";
import Navbar from "../navbar/navbar";
import {ReactComponent as Reading} from './reading.svg';
import { useState } from "react";
import { _get } from "../../utils/api";
import {getToken} from "../../utils/storage";
import Boook from "./book";
import "./index.css";
import { jwtDecode } from "jwt-decode";

import { useNavigate } from "react-router-dom";

const Home = () => {
    const [challenge, setChallenge]=useState([])
    const [books, setBooks]=useState([])
    const [token, setToken] = useState([]);
    const history = useNavigate();

    const getChallenge = () => {
        _get("https://localhost:44335/api/Challenges/GetNewestChallenge").then((challenges) => {
            setChallenge(challenges.data.description);
            console.log(challenges.data.description);
        })
    }

    const getBookRecomandations = () => {
        _get("https://localhost:44335/api/Books/GetBookRecommendations").then((books)=> {
            setBooks(books.data);
        })
    }
    useEffect(() => {
        getChallenge();
        getBookRecomandations();

        if (getToken() !== "") {
            setToken(jwtDecode(getToken()));
        }
        else {
            history("/Authentication/Login");
        }
      }, []);

    if (token && (token?.role === "User" || token?.role === "Admin")) {
        return(
            <div>
                <Navbar></Navbar>
                <div className="container">
                    <div className="container-subtitle">
                    <div className="image"> <Reading /> </div>
                    <div className="description">
                        <h1 className="descriptionTitle">Deciding what to read next?</h1>
                        <h3>You are in the right place</h3>
                        <h3 className="descriptionContent">
                        
    Tell us what titles or genres you’ve enjoyed in the past, and we’ll give you surprisingly insightful recommendations. Reading is fun again! Bookgram means reading adventures that are always right on the nose. Get inspired with your friends to like books you never thought you would!
                        </h3>
                    </div>
                    </div>
                <div className="challenges">
                <div className="challengeTitle" >⚡ Our weekly challenge ⚡</div>
                <div className="challengeContent">{challenge}</div>
                </div>
                <div className="books">
                    <h3 className="rec">Recommendations</h3>
                {
                books.map((product, i) => <Boook {...product} key={i}/>)
                }
            </div>
            </div>
                </div>
        )
    } else {
        history("/Authentication/Login");
    }
};


export default Home;