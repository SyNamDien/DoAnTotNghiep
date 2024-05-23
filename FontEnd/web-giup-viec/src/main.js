import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import { initializeApp } from 'firebase/app'
 
loadFonts()

const firebaseConfig = {
  apiKey: 'AIzaSyDJMVOKc7f9Fd8u5M12sQEB-yQP3vV74AY',
  authDomain: 'vue-upload-91ec4.firebaseapp.com',
  projectId: 'vue-upload-91ec4',
  storageBucket: 'vue-upload-91ec4.appspot.com',
  messagingSenderId: '57173157570',
  appId: '1:57173157570:web:660eec4c67d1b1195afd5b'
}

const app = initializeApp(firebaseConfig)

export{
    app
}

createApp(App).use(store)
  .use(router)
  .use(store)
  .use(vuetify)
  .mount('#app')
