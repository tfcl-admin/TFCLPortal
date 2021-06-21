importScripts('https://www.gstatic.com/firebasejs/4.9.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/4.9.1/firebase-messaging.js');
/*Update this config*/
var config = {
    apiKey: "AIzaSyDMaIWzVA_fbUU93-R4HY1uFiY6tI3ecpM",
    authDomain: "taleem-tech.firebaseapp.com",
    databaseURL: "https://taleem-tech.firebaseio.com",
    projectId: "taleem-tech",
    storageBucket: "taleem-tech.appspot.com",
    messagingSenderId: "147847903012",
    appId: "1:147847903012:web:e11b0d8150e24da22ee5b1",
    measurementId: "G-Y8GG7FNLT6"
  };
firebase.initializeApp(config);

const messaging = firebase.messaging();
messaging.setBackgroundMessageHandler(function(payload) {
  console.log('[firebase-messaging-sw.js] Received background message ', payload);
  // Customize notification here
  const notificationTitle = payload.data.title;
  const notificationOptions = {
    body: payload.data.body,
	icon: 'http://localhost/gcm-push/img/icon.png',
	image: 'http://localhost/gcm-push/img/d.png'
  };

  return self.registration.showNotification(notificationTitle,
      notificationOptions);
});
// [END background_handler]