<template>
  <div class="login-container">
    <div class="login-container__header">
      <img src="@/assets/ic_logo.svg" alt="Mi canasta" />
      <h1 color-rojo>Mi Canasta</h1>
      <p>Administra tus recursos</p>
    </div>
    <div class="login-container__form-container">
      <div class="input-shared-container margin">
        <label class="label-shared-component">Dni</label>
        <input class="input-shared-component" type="text" v-model="dni" />
      </div>

      <div class="input-shared-container margin">
        <label class="label-shared-component">Contraseña</label>
        <input
          class="input-shared-component"
          type="password"
          v-model="contraseña"
        />
      </div>

      <ButtonShared
        class="login-container__button"
        :text="'Ingresar'"
        :type="'large'"
        :bgColor="'red'"
        :loading="loadingButton"
        @Event="autentication"
      />
    </div>

      <ErrorModalShared
      @Event="closeModal"
      v-if="isShowModalError"
      :title="'Hubo un error'"
      :description="
        'Las crendenciales no son correctas'
      "/>
  </div>
</template>

<script>
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";
import AuthService from "../../core/services/auth.service";
export default {
  name: "LoginPage",
  components: { ButtonShared, ErrorModalShared },

  data: function() {
    return {
      dni: "",
      contraseña: "",
      loadingButton: false,
      isShowModalError: false,
    };
  },
  methods: {
    async autentication() {
      this.$data.loadingButton = true;
      try {
        const respuesta = await AuthService.autenticacion(this.$data.dni);
        console.log(respuesta);
        this.$data.loadingButton = false;
        this.$router.push("/home")

      } catch (error) {
        console.log(error);
        this.$data.isShowModalError =  true
        this.$data.loadingButton = false;
      }
    },

    closeModal(){
      this.$data.isShowModalError =  false;
    }
  },
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
</style>
