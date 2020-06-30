<template>
  <div class="request-received-container">
    <div class="request-received__title">
      <h2>Solicitudes Enviadas</h2>
    </div>
    <div class="request-received__allow">
      <div v-if="aceptaSolicitudes" :value="false">
        <p>La familia acepta solicitudes</p>
      </div>
      <div v-else>
        <p>La familia no acepta solicitudes</p>
      </div>
      <a-switch v-model="aceptaSolicitudes" @change="onChange" />
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
import FamiliaService from "../../core/services/familia.service";
export default {
  name: "RequestReceived",
  components: { RequestCard, ErrorModalShared },

  created() {
    const data = AuthService.getUsuarioAutenticacion();
    this.aceptaSolicitudes = data.usuario.familia.aceptaSolicitudes;
    this.getSolicitudes();
  },

  data: function() {
    return {
      usuario: {},
      isShowModalError: false,
      error: { title: "Error" },
      Solicitudes: [],
      aceptaSolicitudes: false
    };
  },
  methods: {
    async onChange() {
      try {
        const data = AuthService.getUsuarioAutenticacion();
        FamiliaService.desactivarSolicitud(data.usuario.familia.familiaId);
        this.getSolicitudes();
      } catch (error) {
        console.log(error);
      }
    },
    async getSolicitudes() {
      try {
        const data = AuthService.getUsuarioAutenticacion();

        this.Solicitudes = [];
        const input = await SolicitudService.obtenerSolicitudesPorFamilia(
          data.usuario.familia.familiaId
        );
        var SolicitudesData = input.data;
        var user = null;

        for (let i = 0; i < SolicitudesData.length; i++) {
          user = await this.getUsuarioData(SolicitudesData[i].dni);
          this.Solicitudes.push({
            title: "Solicitud " + (i + 1),
            nombre: user.data.nombre + " " + user.data.apellidoPaterno,
            dni: user.data.dni,
            familiaId: data.usuario.familia.familiaId,
            render: true
          });
        }
        console.log(this.Solicitudes);
      } catch (error) {
        const data = AuthService.getUsuarioAutenticacion();
        this.$router.push(`/family/family/${data.usuario.familia.familiaId}`);
      }
    },

    getUsuarioData(dni) {
      return UsuarioService.getUsuario(dni);
    },
    closeModal() {
      this.$data.isShowModalError = false;
    }
  }
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
