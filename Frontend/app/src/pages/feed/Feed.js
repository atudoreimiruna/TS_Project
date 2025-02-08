import React, { useEffect, useState } from "react";
import Navbar from "../navbar/navbar";
import Book from "./bookk";
import Post from "./post";
import './feed.css';
import { _get, _post } from "../../utils/api";
import {getToken} from "../../utils/storage";
import {jwtDecode} from "jwt-decode";
import { useNavigate } from "react-router-dom";

const Feed = () => {
    const [seeReviews, setSeeReviews] = useState(false);
    const [seePosts, setSeePosts] = useState(true);
    const [posts, setPosts] = useState([]);
    const [reviews, setReviews] = useState([]);
    const [description, setDescription] = useState();
    const [token, setToken] = useState([]);
    const history = useNavigate();

    const showPosts = () => {
        setSeeReviews(false);
        setSeePosts(true);
    }
    const showReviews = () => {
        setSeePosts(false);
        setSeeReviews(true);
    }

    const getReviews = () => {
        _get("https://localhost:44335/api/Reviews/GetAllReviews").then((challenges) => {
            setReviews(challenges.data);
            console.log(challenges.data);
        })
    }

    const getPosts = () => {
        _get("https://localhost:44335/api/Posts/GetAllPosts").then((challenges) => {
            setPosts([]);
            setPosts(challenges.data);
            console.log(challenges.data);
        })
    }

    const handleSubmit = (e) => {
        
        e.preventDefault();
        _post("https://localhost:44335/api/Posts/CreatePost", {
            userId: token.nameid,
            description: description,
            imagePath: ''
        }).then((response) => {
            if (response) {
                console.log("response: " , response);
                getPosts();
                setDescription('');
            }
        }).catch((err) => {
            console.log(err);
        }) 
    }
    useEffect(() => {
        getPosts();
        getReviews();
        
        if (getToken() !== "") {
            setToken(jwtDecode(getToken()));
        }
        else {
            history("/Authentication/Login");
        }
    }, []);
    
    if (token && (token?.role === "User" || token?.role === "Admin")) {
        return(
            <>
                <Navbar></Navbar>
                <div className="all">
                    <form className="lf" onSubmit={handleSubmit}>
                    
                    <input className="ill" value = {description} onChange={(e) => setDescription(e.target.value)} type="text" placeholder="Create a new post" id="create-new-post" name="description" />

                    <button id="post-button" className="bttn" type="submit"><b>Post</b></button>

                    </form>
                    <div className="buttons">
                        <button id="latest-posts-button" onClick={showPosts} className="button1">See latest Posts</button>
                        <button id="latest-reviews-button" onClick={showReviews} className="button2" >See latest Reviews</button>
                    </div>

                    <div className="or">
                        {seePosts ? <h3 id="posts" className="pt"> Posts ✍</h3> :null}
                        {seePosts ? 
                        posts.map((product, i) => <Book {...product} key={i}/>) : null
                        }
                        {seeReviews ? <h3 id="reviews" className="pt"> Reviews ✍</h3> :null}
                        {seeReviews ? 
                        reviews.map((product, i) => <Post {...product} key={i}/>):null
                        }
                    </div>
                </div>
            </>
        );
    } else {
        history("/Authentication/Login");
    }
};

export default Feed;