<template>
    <div>
        <h3 v-if="user">Welcome, {{user.username}}</h3>
        <h3 v-if="!user">All routes</h3>
        <p>Home:            https://localhost:5002/</p>
        <p>Company List:    https://localhost:5002/companyList</p>
        <p>Add a Company:   https://localhost:5002/addCompany</p>
        <p>Login:           https://localhost:5002/login</p>
        <p>Register:        https://localhost:5002/register</p>
        <p>Forgot password: https://localhost:5002/forgot</p>
        <p>Reset:           https://localhost:5002/reset/:token</p>
    </div>
</template>

<script>
import { mapGetters } from 'vuex';
    export default {
        name: 'Home',
        computed: {
        ...mapGetters(['user'])
        }
    }
</script>