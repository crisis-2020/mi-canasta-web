<template>
  <div class="request-sent-container">
    <div class="request-sent__title">
      <h2>Solicitudes Enviadas</h2>
    </div>
    <div class="request-sent__list">
      <request-card
        v-for="(request, index) in nombreFam"
        :request="request"
        v-bind:key="index"
        @actualizar-tarjeta="returnHome"
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
import RequestCard from "./components/request.card.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component";
import SolicitudService from "../../core/services/solicitud.service";
import AuthService from "../../core/services/auth.service";
export default {
  name: "RequestsSentPage",
  components: { RequestCard, ErrorModalShared },
  created() {
    this.$data.usuario = AuthService.getUsuarioAutenticacion();
    this.getSolicitud();
  },
  data: function() {
    return {
      usuario: {},
      mock: [{ familyName: "Familia82BDH" }],
      isShowModalError: false,
      error: { title: "Error" },
      nombreFam: []
    };
  },
  methods: {
    async getSolicitud() {
      try {
        this.nombreFam = [];
        let dni = this.$data.usuario.usuario.usuario.dni;
        const input = await SolicitudService.obtenerSolicitudes(dni);
        this.$data.nombreFam = [
          {
            familyName: input.data.nombreFamilia,
            dni: dni
          }
        ];
      } catch (error) {
        console.log(error);
        this.$data.usuario.usuario.solicitud = null;
        this.error.description =
          "No tiene una solicitud activa para ingresar a un grupo familiar";
        this.$data.isShowModalError = true;
        AuthService.saveUsuarioAutenticacion(this.$data.usuario);
      }
    },
    closeModal() {
      this.$data.isShowModalError = false;
    },

    returnHome() {
      this.$router.push("/start/home");
    }
  }
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

.request-sent__list {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
}
</style>
