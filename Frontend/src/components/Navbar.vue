<template>
    <div id="nav">
        <nav class="navbar navbar-expand navbar-light fixed-top">
            <div class="container">
                <router-link to="/" class="navbar-brand">Home</router-link>
                <div class="collapse navbar-collapse">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <router-link to="/companyList" class="nav-link">Company List</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/addCompany" class="nav-link">Add a company</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/login" class="nav-link">Login</router-link>
                        </li>
                    </ul>
                    
                </div>
            </div>
        </nav>
    </div>
</template>

<script>
import {mapGetters} from 'vuex'
export default {
    name: 'Navbar',
    props: ['appusers'],
    methods: {
        
        //Logout method
        handleClick() {
            localStorage.removeItem('token');
            this.$store.dispatch('appusers', null);
            this.$router.push('/login');
        }
    },
    computed: {
        ...mapGetters(['appusers'])
    }
};
</script>

