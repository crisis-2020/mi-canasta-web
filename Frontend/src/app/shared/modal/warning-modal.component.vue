<template>
  <div class="container-modal-warning">
      <div class="card">
          <img src="@/assets/ic_warning.svg" alt="">
          <p>{{description}}</p>
        <ButtonShared
            class="button"
            :text="'Entendido'"
            :type="'large'"
            :bgColor="'yellow'"
            @Event="confirmation"
        ></ButtonShared>
      </div>
  </div>
</template>

<script>
import ButtonShared from "../button/button.component.vue";
export default {
    name: "WarningModalShared",
    components: {ButtonShared},
    props: ['description'],
    methods: {
        confirmation(){
            this.$emit('CloseModal')
        }
    }

}
</script>

<style>
.container-modal-warning{
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

.container-modal-warning .card{
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
.container-modal-warning .card img{

    margin-bottom: 12px;
}

.container-modal-warning .card p{
    width: 80%;
    text-align: center;
    font-size: 14px;
    margin-bottom: 48px;
}



</style>