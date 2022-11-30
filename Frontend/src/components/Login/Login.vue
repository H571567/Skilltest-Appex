<template>
    <form submit.prevent="handleSubmit">
        
        <error v-if="error" :error="error" />

        <h3>Login</h3>

        <div class="form-group">
            <label>Email</label>
            <input type="email" class="form-control" v-model="email" placeholder="Email"/>
        </div>
        <div class="form-group">
            <label>Password</label>
            <input type="password" class="form-control" v-model="password" placeholder="Password"/>
        </div>

        <div>
            <p class="forgot-password">
                <router-link to="/register" color="blue">Register here</router-link>
            </p>
            
        </div>

        <div>
            <p class="forgot-password text-right">
                <router-link to="/forgot">Forgot password?</router-link>
            </p>
        </div>

        <button class="btn btn-primary btn-block">Login</button>
    </form>
</template>

<script>
    import axios from 'axios'
    import Error from './Error.vue'
    export default {
        name: 'Login',
        components: {
            Error
        },
        data() {
            return {
                email: '',
                password: '',
                error: ''
            }
        },
        methods: {
            async handleSubmit() {
                
                try {
                    const response = await axios.post('Login', {
                        email: this.email,
                        password: this.password
                    });
                    
                    // store token
                    localStorage.setItem('token', response.data.token);
                    this.$store.dispatch('appusers', response.data.user);
                    this.$router.push('/');
                } catch (e) {
                    this.error = 'Invalid email/password'
                }

            }
        }
    }
</script>
