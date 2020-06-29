<template>
  <div v-if="request.render" class="request-received-card">
    <div class="request-received-card__title">
      <h2>{{ request.title }}</h2>
    </div>
    <div class="request-received-card__body">
      <h3>{{ request.nombre }}</h3>
      <p id="dni">{{ request.dni }}</p>
      <div class="request-received-card__buttons">
        <button class="accept-button" v-on:click="aceptedSolicitude">
          Aceptar
        </button>
        <button class="deny-button" v-on:click="deniedSolicitude">
          Denegar
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import SolicitudService from "../../../core/services/solicitud.service";

export default {
  name: "RequestCard",

  props: ["request"],

  methods: {
    async deniedSolicitude() {
      try {
        const res = await SolicitudService.denegarSolicitud(this.request.dni);
        console.log(res);
        this.$emit("actualizar-tarjeta");
      } catch (error) {
        console.log(error);
      }
    },

    async aceptedSolicitude() {
      try {
        const res = await SolicitudService.aceptarSolicitud({
          familiaId: Number(this.request.familiaId),
          dni: this.request.dni,
        });
        console.log(res);
        this.$emit("actualizar-tarjeta");
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style>
.request-received-card {
  width: 264px;
  border-radius: 4px;
  background: #fafafa;
  overflow: hidden;
  margin: 0 0 32px 0;
}
.request-received-card__title {
  width: 100%;
  background: #f76a8c;
  padding: 12px 0px;
}

.request-received-card__title h2 {
  font-size: 16px;
  font-weight: 600;
  color: #ffffff;
  margin: 0;
  text-align: center;
}
.request-received-card__body h3 {
  font-size: 20px;
  font-weight: 600;
  color: #000;
  text-align: center;
  margin: 24px 0 8px 0;
}

.request-received-card__body p {
  font-size: 16px;
  margin: 0;
  color: #000;
  text-align: center;
}

.request-received-card__buttons {
  width: 100%;
  display: flex;
  justify-content: space-around;
  padding: 24px 0;
}
.request-received-card__buttons button {
  font-size: 12px !important;
  padding: 8px 16px;
  border-radius: 6px;
  border: none;
  font-weight: 600;
}
.request-received-card__buttons .deny-button {
  background: rgba(247, 106, 140, 0.21);
  color: #f76a8c;
}
.request-received-card__buttons .accept-button {
  background: #f76a8c;
  color: #ffffff;
}
</style>
