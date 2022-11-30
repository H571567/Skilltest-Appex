<template>
    <form @submit.prevent="handleSubmit">
        
        <error v-if="error" :error="error" />

        <h3>Add a company</h3>

        <div class="form-group">
            <label>Organisation number</label>
            <input type="text" class="form-control" v-model="orgNr" placeholder="OrgNr"/>
        </div>

        <div class="form-group">
            <label>Company Name</label>
            <input type="text" class="form-control" v-model="name" placeholder="Name"/>
        </div>

        <div class="form-group">
            <label for="notes">Notes</label>
            <br/>
            <textarea id="notes" name="notes" rows="4" cols="40" v-model="note" placeholder="Notes..."></textarea>
        </div>


        <button class="btn btn-primary btn-block">Add</button>
    </form> 
</template>

<script>
    import axios from 'axios'
    import Error from '../Login/Error.vue'
    export default {
        name: "AddCompany",
        data() {
            return {
                orgNr: '',
                name: '',
                note: '',
                error: ''
            }
        },
        components: {
            Error
        },
        methods: {
            async handleSubmit(){
                try {
                    const response = await axios.post('companies', {
                        OrgNr: this.orgNr,
                        Name: this.name,
                        Note: this.note
                    });
                    
                    console.log(response)
                    //this.$router.push('/login');
                } catch (e) {
                    this.error = 'Error occurred!'
                }

            }
        }
    }
</script>