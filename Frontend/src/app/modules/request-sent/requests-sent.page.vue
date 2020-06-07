<template>
  <div class="request-sent-container">
    <div class="request-sent__title">
      <h2>Solicitudes Enviadas</h2>
    </div>
    <div class="request-sent__list">
      <request-card
        v-for="(request, index) in mock"
        :request="request"
        v-bind:key="index"
      ></request-card>
    </div>
  </div>
</template>

<script>
import RequestCard from "./components/request.card.vue";
export default {
  name: "RequestsSentPage",
  components: { RequestCard },
  data: function() {
    return {
      mock: [{ familyName: "Familia82BDH" }],
    };
  },
};
</script>

<style>
.request-sent-container {
  width: 100%;
  padding: 0 32px;
}
.request-sent__title {
  margin-top: 24px;
  margin-bottom: 48px;
}
.request-sent__title h2 {
  font-size: 20px;
  font-weight: 600;
  color: #000000;
  text-align: center;
}

.request-sent__list{
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: center;
}
</style>
