<template> 
    <form @submit.prevent="handleSubmit">
        
        <error v-if="error" :error="error" />

        <h3>Sign Up</h3>

        <div class="form-group">
            <label>Email</label>
            <input type="text" class="form-control" v-model="email" placeholder="Email"/>
        </div>

        <div class="form-group">
            <label>Name</label>
            <input type="text" class="form-control" v-model="name" placeholder="Name"/>
        </div>

        <div class="form-group">
            <label>Password</label>
            <input type="Password" class="form-control" v-model="password" placeholder="Password"/>
        </div>

        <div class="form-group">
            <label>Confirm Password</label>
            <input type="Password" class="form-control" v-model="password_confirm" placeholder="Confirm Password"/>
        </div>
        <br/>
        <button class="btn btn-primary btn-block">Sign Up</button>
    </form> 
</template>

<script>
    import axios from 'axios'
    import Error from './Error.vue'
    export default {
        name: 'Register',
        data() {
            return {
                email: '',
                password: '',
                password_confirm: '',
                name: '',
                error: ''
            }
        },
        components: {
            Error
        },
        methods: {
            async handleSubmit(){
                try {
                    await axios.post('api/Register', {
                        Email: this.email,
                        Name: this.name,
                        Password: this.password
                    });
                    
                    this.$router.push('/login');
                } catch (e) {
                    this.error = 'Error occurred!'
                }

            }
        }
    }
</script>