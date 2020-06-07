<template>
  <div class="request-received-container">
    <div class="request-received__title">
      <h2>Solicitudes Enviadas</h2>
    </div>
    <div class="request-received__allow">
      <p>Desactivar solicitudes</p>

      <a-switch default-checked />
    </div>
    <div class="request-received__list">
      <request-card
        v-for="(request, index) in mock"
        :request="request"
        v-bind:key="index"
      ></request-card>
    </div>
  </div>
</template>

<script>
import RequestCard from "./components/request-received.card.vue";
export default {
  name: "RequestReceived",
  components: {RequestCard},
  data:function(){
      return{
          mock: [
              {title:'Solicitud 10', nombre: 'Felipe Gomez', dni:'73044851'},
              {title:'Solicitud 10', nombre: 'Felipe Gomez', dni:'73044851'},
              {title:'Solicitud 10', nombre: 'Felipe Gomez', dni:'73044851'},
              {title:'Solicitud 10', nombre: 'Felipe Gomez', dni:'73044851'}
          ]
      }
  }
};
</script>

<style>
.request-received-container{
    width: 100%;
    padding: 24px 32px;
    height: calc(100vh - 128px);
    overflow-y: auto;
}


.request-received__title {
  margin-top: 24px;
  margin-bottom: 24px;
}
.request-received__title h2 {
  font-size: 20px;
  font-weight: 600;
  color: #000000;
  text-align: left;
}
.request-received__allow{
    margin-bottom: 24px;
}
.request-received__allow p{
    margin-bottom: 8px;
}
.request-received__list{
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: center;
}

</style>
