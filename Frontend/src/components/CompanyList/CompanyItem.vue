<template>
    <div class="popup">
        <div class="popup-inner">
            <div>
                <h3>{{data.Name}}</h3>
                <p>{{data.orgNre}}</p>
                <form submit.prevent="handleSubmit">
                    <div class="form-group">
                        <label for="note">Notes</label>
                        <textarea id="note" name="note" rows="4" cols="40" v-model="new_note" placeholder={{data.Note}}></textarea>
                    </div>
                    <div class="form-group">
                        <label>Confirm Password</label>
                        <input type="Password" class="form-control" v-model="password_confirm" placeholder="Confirm Password"/>
                    </div>
                    <button class="btn btn-primary btn-block" @click="CloseButton()">Update</button>
                </form>
            </div>
            <button class="popup-close">
                Close
            </button>
        </div>
    </div>
</template>

<script>
//import axios from 'axios';

    export default {
        name: 'CompanyItem',
        data() {
            return {
                new_note: ''
            }
        },
        props: ['name', 'orgNr', 'note', 'CloseButton'],
        methods: {
            async handleSubmit(){
                console.log('Changed Note!')
            }
        }
    }
</script>

<style lang="scss" scoped>
    .popip {
        position: fixed;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        z-index: 99;
        background-color: rgba(0,0,0, 0.2);
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .popup-inner {
        background: white;
        padding: 32px;
    }
</style>