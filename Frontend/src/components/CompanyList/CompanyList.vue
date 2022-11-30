<template>
    <div>
        <h3 class="companyTitle">Companies</h3>

        <div>
            <input type="text" placeholder="Search..">
        </div>
        <br/>

        <div>
            <ul class="card columns" data-colmuns="2" v-for="item in list" :key="item.Id">
                    <h4 class="title">{{item.Name}}</h4>
                    <p class="secondary-text">{{item.orgNr}}</p>
                    <button class="btn btn-primary btn-block buttonTrigger" @click="() => ToggleTrigger('buttonTrigger')">Show</button>
                    <br/>
                    <CompanyItem 
                        v-if="companyItemTrigger.buttontrigger" 
                        :name="item.Name"
                        :orgNr="item.orgNr"
                        :note="item.Note"
                        :CloseButton="() => ToggleTrigger('buttonTrigger')"
                    />
            </ul>
        </div>
    </div>
</template>

<script>
    //import axios from 'axios'
    import {ref} from 'vue'
    import CompanyItem from './CompanyItem.vue'

    export default {
        setup() {
            const companyItemTrigger = ref({
                buttonTrigger: false
            })

            const ToggleTrigger = (trigger) => {
                companyItemTrigger.value[trigger] = !companyItemTrigger.value[trigger]
                console.log('Clicked')
            }

            return {
                companyItemTrigger,
                ToggleTrigger
            }
        },
        name: 'CompanyList',
        data() {
            return {
                list: [ {ID: 1, orgNr: '937 896 670', Name: 'Skudnes&Aakra Sparebank', Note: ''},
                        {ID: 2, orgNr: '123 456 789', Name: 'En bedrift', Note: ''},
                        {ID: 3, orgNr: '123 456 789', Name: 'En bedrift', Note: ''},
                        {ID: 4, orgNr: '123 456 789', Name: 'En bedrift', Note: ''},
                        {ID: 5, orgNr: '123 456 789', Name: 'En bedrift', Note: ''}
                ]
            }
        },
        methods: {
            openCard() {

            }
        },
        components: {
            CompanyItem
        }
    }
</script>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Quicksand&display=swap');
            .card {
                background-color: #fff;
                border-radius: 2rem;
                box-shadow: rgb(150,150,150) 0px 1px 3px;
                width: 250px;
                height: 10rem;
                padding: 1rem;
                font-family: 'Quicksand', sans-serif;
                columns: 2;
                -webkit-columns: 2;
                -moz-columns: 2;
            }
            .title {
                margin-bottom: 0%;
            }
            .columns{
                float: left;
                position: relative;
                margin-right: 20px;
            }

            .buttonTrigger {
                bottom: 1rem;
                position: absolute;
                width: 50%;
            }
            .companyTitle {
                display: flex;
                left: 5rem;
            }
</style>
