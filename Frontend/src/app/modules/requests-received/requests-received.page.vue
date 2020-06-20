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
        v-for="(request, index) in Solicitudes"
        :request="request"
        v-bind:key="index"
      ></request-card>
    </div>
  </div>
</template>

<script>
import RequestCard from "./components/request-received.card.vue";
import SolicitudService from "../../core/services/solicitud.service";
import UsuarioService from "../../core/services/usuario.service";
export default {
  name: "RequestReceived",
  components: { RequestCard },

  created() {
    this.$data.idFamilia = this.$route.params.idFam;
    this.getSolicitudes();
  },

  data: function() {
    return {
      Solicitudes: [],
      idFamilia: null,
    };
  },
  methods: {
    async getSolicitudes() {
      const input = await SolicitudService.obtenerSolicitudesPorFamilia(
        this.$data.idFamilia
      );
      var SolicitudesData = input.data;
      var usuario;
      for (let i = 0; i < SolicitudesData.length; i++) {
        usuario = await this.getUsuarioData(SolicitudesData[i].dni);
        this.Solicitudes.push({
          title: "Solicitud " + (i + 1),
          nombre: usuario.data.nombre + " " + usuario.data.apellidoPaterno,
          dni: usuario.data.dni,
          familiaId: this.$data.idFamilia,
        });
      }
      console.log(this.Solicitudes);
    },
    getUsuarioData(dni) {
      return UsuarioService.getUsuario(dni);
    },
  },
};
</script>

<style>
.request-received-container {
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
.request-received__allow {
  margin-bottom: 24px;
}
.request-received__allow p {
  margin-bottom: 8px;
}
.request-received__list {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
}
</style>
