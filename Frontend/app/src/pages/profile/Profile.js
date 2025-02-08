import React, { isValidElement, useEffect } from "react";
import ReactDom from "react-dom";
import Modal from "react-modal";
import Navbar from "../navbar/navbar";
import Post from "./Post";
import profileStyles from "./Profile.module.css";
import { ReactComponent as Cancel } from "./cancel.svg";
import { ReactComponent as Instagram } from "./instagram.svg";
import { ReactComponent as Review } from "./review.svg";
import { ReactComponent as Friends } from "./friends.svg";
import { _get } from "../../utils/api";
import { getToken } from "../../utils/storage";
import { useState } from "react";
import { jwtDecode} from "jwt-decode";
import { useNavigate } from "react-router-dom";

export default function Profile() {
  const [modalIsOpenFriends, setIsOpenFriends] = React.useState(false);
  const [modalIsOpenReviews, setIsOpenReviews] = React.useState(false);
  const [token, setToken] = useState(() => {
    return jwtDecode(getToken("token"))
  });
  const [friendshipsList, setFriendshipsList] = useState([]);
  const [postsList, setPostsList] = useState([]);
  const [reviewsList, setReviewsList] = useState([]);
  const history = useNavigate();

  // friends modal
  function openModalFriends() {
    setIsOpenFriends(true);
  }

  function afterOpenModalFriends() {}

  function closeModalFriends() {
    setIsOpenFriends(false);
  }

  // reviews modal
  function openModalReviews() {
    setIsOpenReviews(true);
  }

  function afterOpenModalReviews() {}

  function closeModalReviews() {
    setIsOpenReviews(false);
  }


  // prietenii userului
  const getFriendships = () => {
    _get("https://localhost:44335/api/Friendships/GetAllFriendships").then(
      (friendships) => {
        console.log("date: " , friendships.data);
        setFriendshipsList(friendships.data);
        console.log("Lista: ", friendshipsList);
      }
    );
  };

  // postarile unui user 
  const getPosts = async () => {
    await (_get(`https://localhost:44335/api/Posts/GetAllUser${token.nameid}Posts`).then(
      (posts) => {
        console.log(posts);
        setPostsList(posts.data);
        console.log("postari: ", postsList);
      }
    ));
  };

  // review-urile user-ului
  const getReviews = async () => {
    await (_get(`https://localhost:44335/api/Reviews/GetReviewsByUser/${token.nameid}`).then(
      (reviews) => {
        console.log(reviews);
        setReviewsList(reviews.data);
        console.log("review-uri: ", reviewsList);
      }
    ));
  };


  useEffect(() => {
    getPosts();
    getFriendships();
    getReviews();
  }, [] );


  if (token && (token?.role === "User" || token?.role === "Admin")) {
    return (
      <div className={profileStyles.MainProfileDiv}>
        <Navbar></Navbar>
        <div className={profileStyles.profileContainer}>
          <div className={profileStyles.topPortion}>
            <div className={profileStyles.userProfileBgImage}>
              <img
                id={profileStyles.prfBgImg}
                src="https://i.pinimg.com/originals/7b/af/00/7baf007df75b2a7c2e484b272ab63912.jpg"
                alt=""
                srcSet=""
              />
            </div>
            <div className={profileStyles.userProfileImg}>
              <img
                id={profileStyles.prfImg}
                src="https://media.istockphoto.com/id/996701760/vector/pop-art-comic-book-nerdy-bookworm-female-student-girl-studying-and-reading-book-vector.jpg?s=612x612&w=0&k=20&c=aDBXl2ANY9fIisaS8Trg91hxgeyZHejGWmXYUV7bnkM="
                alt=""
                srcSet=""
              />
              <div className={profileStyles.userName}>
                <h1 id={profileStyles.name}>
                  {token.unique_name}
                  </h1>
              </div>
            </div>

            <div className={profileStyles.middlePortionUp}>
              <div>
                <Friends
                  className={profileStyles.middlePortionUpBtn}
                  onClick={openModalFriends}
                ></Friends>
                <div>
                  <Modal
                    isOpen={modalIsOpenFriends}
                    onAfterOpen={afterOpenModalFriends}
                    onRequestClose={closeModalFriends}
                    className={profileStyles.modalF}
                    contentLabel="Example Modal"
                  >
                    <div className={profileStyles.modalFriends}>
                      <h2>Friends list</h2>
                      <div
                        className={profileStyles.closeModalFriendsBtn}
                        onClick={closeModalFriends}
                      >
                        <Cancel></Cancel>
                      </div>
                    </div>
                    <div className={profileStyles.friendslist}>
                      {friendshipsList.map((val, key) => {
                        return <li>{val.friendName}</li>;
                      })}
                    </div>
                  </Modal>
                </div>
              </div>
              <div>
                <Review 
                  className={profileStyles.middlePortionUpBtn}
                  onClick = {openModalReviews}
                >
                </Review>
                <div>
                  <Modal
                    isOpen={modalIsOpenReviews}
                    onAfterOpen={afterOpenModalReviews}
                    onRequestClose={closeModalReviews}
                    className={profileStyles.modalF}
                    contentLabel="Example Modal"
                  >
                    <div className={profileStyles.modalFriends}>
                      <h2>Reviews list</h2>
                      <div
                        className={profileStyles.closeModalFriendsBtn}
                        onClick={closeModalReviews}
                      >
                        <Cancel></Cancel>
                      </div>
                    </div>
                    <div className={profileStyles.friendslist}>
                      {reviewsList.map((val, key) => {
                        return (
                        <div>
                          <li>{val.title}</li>
                          <p className={profileStyles.comment}>{val.comment}</p>
                        </div>)
                      })}
                    </div>
                  </Modal>
                </div>
              </div>
              <div>
                <a href="https://www.instagram.com/">
                  <Instagram
                    className={profileStyles.middlePortionUpBtn}
                  ></Instagram>
                </a>
              </div>
            </div>
            <div className={profileStyles.middlePortion}>
              <div className={profileStyles.friend}>
                <h3>Friends</h3>
              </div>
              <div className={profileStyles.reviews}>
                <h3>Reviews</h3>
              </div>
              <div className={profileStyles.instagram}>
                <h3>Instagram</h3>
              </div>
            </div>
          </div>

          <div className={profileStyles.bottomPortion}>
            <div className={profileStyles.leftSide}>
              {postsList.map((val, i) => <Post {...val} key={i} />)}
            </div>
          </div>
        </div>
      </div>
    );
  } else {
    history("/Authentication/Login");
  }
}