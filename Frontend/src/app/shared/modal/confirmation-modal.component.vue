<template>
      <div class="container-modal-confirmation">
        <div class="card">
            <h2>{{title}}</h2>
            <p>{{description}}</p>

            <div class="list-button">

            <ButtonShared
                :text="'Si'"
                :type="'small'"
                :bgColor="'red'"
                 @Event="yes"
            ></ButtonShared>
            <ButtonShared
            class="no-button"
                :text="'No'"
                :type="'small'"
                 @Event="no"
            ></ButtonShared>
            </div>

        </div>
    </div>
</template>

<script>
import ButtonShared from "../button/button.component.vue";

export default {
    name: "ConfirmationModalShared",
    components: {ButtonShared},
    props: ['title','description'],
    methods: {
        yes(){
            this.$emit('YesEvent')
        },
        no(){
            this.$emit('NoEvent')
        }
    }
}
</script>

<style>
.container-modal-confirmation{
    width: 100%;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    position: absolute;
    top: 0;
    left: 0;
    z-index: 5;
    background: rgba(0, 0, 0, .37);


}

.container-modal-confirmation .card{
    width: 280px;
    height: 280px;
    border-radius: 8px;
    background: #ffffff;
    position: relative;
    display: flex;
    align-items: center;
    flex-direction: column;
    justify-content: center;
    
}
.container-modal-confirmation .card h2{
    font-size: 20px;
    font-weight: 600;
    color: #FF5A82;
    margin-bottom: 12px;
}

.container-modal-confirmation .card p{
    width: 80%;
    text-align: center;
    font-size: 14px;
    margin-bottom: 48px;
}

.container-modal-confirmation .list-button{
    width: 80%;
    margin: 0 auto;
    display: flex;
    justify-content: space-around;
    align-items: center;
}
.no-button{
    background: #FFDBE4;
    color: #F76A8C;
}
</style>