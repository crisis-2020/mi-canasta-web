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
        @actualizar-tarjeta="getSolicitudes"
      ></request-card>
    </div>
    <ErrorModalShared
      @Event="closeModal"
      v-if="isShowModalError"
      :title="error.title"
      :description="error.description"
    />
  </div>
</template>

<script>
import ErrorModalShared from "../../shared/modal/error-modal.component";
import RequestCard from "./components/request-received.card.vue";
import SolicitudService from "../../core/services/solicitud.service";
import UsuarioService from "../../core/services/usuario.service";
import AuthService from "../../core/services/auth.service";
export default {
  name: "RequestReceived",
  components: { RequestCard, ErrorModalShared },

  created() {
    //this.$data.idFamilia = this.$route.params.idFam;
    this.$data.usuario = AuthService.getUsuarioAutenticacion();
    this.getSolicitudes();
  },

  data: function() {
    return {
      usuario: {},
      isShowModalError: false,
      error: { title: "Error" },
      Solicitudes: [],
    };
  },
  methods: {
    async getSolicitudes() {
      try {
        let usuario = this.$data.usuario.usuario;
        this.Solicitudes = [];
        const input = await SolicitudService.obtenerSolicitudesPorFamilia(
          usuario.familia.familiaId
        );
        var SolicitudesData = input.data;
        var user = null;

        for (let i = 0; i < SolicitudesData.length; i++) {
          user = await this.getUsuarioData(SolicitudesData[i].dni);
          this.Solicitudes.push({
            title: "Solicitud " + (i + 1),
            nombre: user.data.nombre + " " + user.data.apellidoPaterno,
            dni: user.data.dni,
            familiaId: this.$data.idFamilia,
            render: true,
          });
        }
        console.log(this.Solicitudes);
      } catch (error) {
        console.log(error);
        this.error.description = "No existen solicitudes pendientes";
        this.$data.isShowModalError = true;
      }
    },

    getUsuarioData(dni) {
      return UsuarioService.getUsuario(dni);
    },
    closeModal() {
      this.$data.isShowModalError = false;
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
