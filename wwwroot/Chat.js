// Import the functions you need from the SDKs you need
//import { initializeApp } from "firebase/app";
//import { getAnalytics } from "firebase/analytics";
//import firebase from 'firebase/app';
//import 'firebase/auth';
//import 'firebase/firestore';
//const init = require('firebase/app')
const db = require('firebase/firestore')
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
//const firebaseConfig = {
   // apiKey: "AIzaSyBA4HQjz91UxQNNpJfzYexMbaIVwGn52Ps",
   // authDomain: "test-7c0d7.firebaseapp.com",
   // projectId: "test-7c0d7",
  //  storageBucket: "test-7c0d7.appspot.com",
    //messagingSenderId: "670484252112",
   // appId: "1:670484252112:web:5fe9d1d6ea76131645e5d5"
//};
// Initialize Firebase
//export.app = init.initializeApp(firebaseConfig).onRun;

//var db = firebaseApp.firestore();
var database = db.getFirestore();

document.getElementById("message-form").addEventListener("submit", sendMessage);

// send message to db
function sendMessage(e) {
    e.preventDefault();

    // get values to be submitted
    const timestamp = Date.now();
    const messageInput = document.getElementById("message-input");
    const message = messageInput.value;

    // clear the input box
    messageInput.value = "";

    //auto scroll to bottom
    document
        .getElementById("messages")
        .scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });

    // create db collection and send in the data
    db.ref("messages/" + timestamp).set({
        username,
        message,
    });
}

// display the messages
// reference the collection created earlier
const fetchChat = db.ref("messages/");

// check for new messages using the onChildAdded event listener
fetchChat.on("child_added", function (snapshot) {
    const messages = snapshot.val();
    const message = `<li class=${username === messages.username ? "sent" : "receive"
        }><span>${messages.username}: </span>${messages.message}</li>`;
    // append the message on the page
    document.getElementById("messages").innerHTML += message;
});