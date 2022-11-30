import { createApp } from 'vue'
import './axios'
import {createStore} from 'vuex'
import { createRouter, createWebHistory} from 'vue-router'
//Components
import App from './App.vue'
import Home from './components/Home.vue'
import Login from './components/Login/Login.vue'
import Register from './components/Login/Register.vue'
import Forgot from './components/Login/Forgot.vue'
import Reset from './components/Login/Reset.vue'
import AddCompany from './components/AddACompany/AddCompany.vue'
import CompanyList from './components/CompanyList/CompanyList.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: '/', component: Home},
        {path: '/login', component: Login},
        {path: '/register', component: Register},
        {path: '/forgot', component: Forgot},
        {path: '/reset/:token', component: Reset},
        {path: '/addCompany', component: AddCompany},
        {path: '/companyList', component: CompanyList}
        
    ]
})

const store = createStore({
    state () {
      return {
        user: null
      }
    },
    mutations: {user(state, user) {
        state.user = user;
    }},
    actions: {
        user(context, user) {
            context.commit('appuser', user);
        }
    }
  })


const app = createApp(App)

app.use(router)
app.use(store)
app.mount('#app')
