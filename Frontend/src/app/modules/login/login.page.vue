<template>
  <div class="login-container">
    <div class="login-container__header">
      <img src="@/assets/ic_logo.svg" alt="Mi canasta" />
      <h1 color-rojo>Mi Canasta</h1>
      <p>Administra tus recursos</p>
    </div>
    <div class="login-container__form-container">
      <div class="input-shared-container">
        <label class="label-shared-component">Dni</label>
        <input class="input-shared-component" type="text" v-model="dni" maxlength="8" />
      </div>

      <div class="input-shared-container">
        <label class="label-shared-component">Contraseña</label>
        <input class="input-shared-component" type="password" v-model="contrasena" maxlength="50" />
      </div>

      <ButtonShared
        class="login-container__button"
        :text="'Ingresar'"
        :type="'large'"
        :bgColor="'red'"
        :loading="loadingButton"
        :disabled="loadingButton"
        @Event="autentication"
      />
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
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";
import AuthService from "../../core/services/auth.service";
import Usuario from "../../core/model/usuario.model";
import ValidacionService from "../../core/services/validacion.service";
import SolicitudService from "../../core/services/solicitud.service";
export default {
  name: "LoginPage",
  components: { ButtonShared, ErrorModalShared },

  data: function() {
    return {
      dni: "",
      contrasena: "",
      loadingButton: false,
      isShowModalError: false,
      error: { title: "Error" }
    };
  },
  methods: {
    async autentication() {
      this.$data.loadingButton = true;
      try {
        const usuario = new Usuario(this.$data.dni, this.$data.contrasena);

        if (!ValidacionService.validarDni(usuario.dni)) {
          throw "FormatDniException";
        } else if (!ValidacionService.validarContrasena(usuario.contrasena)) {
          throw "FormatContrasenaException";
        }

        localStorage.setItem("dni", this.$data.dni);
        await AuthService.autenticacion(usuario).then(e => {
          this.$data.loadingButton = false;
          AuthService.saveUsuarioAutenticacion(e.data);

          if (e.data.usuario.solicitud != null) {
            this.$router.push(`/start/requests-sent`);
          } else if (e.data.usuario.tienda != null) {
            this.$router.push(`/home/dealers`);
          } else if (e.data.usuario.familia != null) {
            this.validarSolicitudes(e);
          } else {
            this.$router.push("/start/home");
          }
        });
      } catch (error) {
        if (
          error instanceof Object &&
          (error.response.data.exception == "UserLoginNotFoundException" ||
            error.response.data.exception == "UserLoginIncorrectException")
        ) {
          this.error.description =
            "El usuario o contraseña ingresado es incorrecto";
        } else if (error == "FormatDniException") {
          this.error.description =
            "El DNI ingresado debe contener 8 caracteres y ser solo números";
        } else if (error == "FormatContrasenaException") {
          this.error.description =
            "La contraseña ingresada no debe estar vacía, tener mas de 50 caracteres o contener espacios en blanco";
        }

        this.$data.isShowModalError = true;
        this.$data.loadingButton = false;
      }
    },
    async validarSolicitudes(e) {
      try {
        await SolicitudService.obtenerSolicitudesPorFamilia(
          e.data.usuario.familia.familiaId
        );

        this.$router.push(`/family/requests-received`);
      } catch (error) {
        this.$router.push(`/family/family/${e.data.usuario.familia.familiaId}`);
      }
    },

    closeModal() {
      this.$data.isShowModalError = false;
    }
  }
};
</script>

<style>
.login-container {
  position: relative;
  width: 100%;
  height: 100%;
}
.login-container__header {
  padding-top: 64px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.login-container__header img {
  width: 48px;
}
.login-container__header h1 {
  font-size: 24px;
  font-weight: 700;
  margin: 16px 0 8px 0;
}
.login-container__header p {
  font-size: 14px;
}

.login-container__form-container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  margin-top: 32px;
}

.login-container__button {
  margin-top: 24px;
}
.input-shared-container {
  margin-bottom: 24px;
}
</style>
