import axios from 'axios'

axios.defaults.baseURL = 'https://localhost:5002/';
axios.defaults.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('token');