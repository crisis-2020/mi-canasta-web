<template>
  <div class="home-container">
    <div class="field-container margin">
      <label class="label-shared-component grupo-familiar-label"
        >Grupo Familiar</label
      >
      <input
        class="input-shared-component"
        type="text"
        v-model="grupoFamiliar"
      />
    </div>

    <div class="home-container__list-button">
      <ButtonShared
        :loading="loadingCreaFamiliarButton"
        :disable="grupoFamiliar.length < 1"
        :text="'Crear'"
        :type="'small'"
        :bgColor="'red'"
        @Event="crearGrupo"
      ></ButtonShared>

      <ButtonShared
        :disable="grupoFamiliar.length < 1"
        :text="'Unirse'"
        :type="'small'"
        :bgColor="'yellow'"
        @Event="unirseGrupo"
      >
      </ButtonShared>
    </div>

    <ErrorModalShared
      v-if="errorFlagModal"
      :title="'Lo sentimos'"
      :description="'El nombre del grupo  familiar ya existe'"
      @Event="cerrarModal"
    >
    </ErrorModalShared>
  </div>
</template>

<script>
import FamiliaService from "../../core/services/familia.service";
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";
export default {
  name: "HomePage",
  components: { ButtonShared, ErrorModalShared },
  data: function() {
    return {
      grupoFamiliar: "",
      loadingCreaFamiliarButton: false,
      errorFlagModal: false,
    };
  },

  methods: {
    async crearGrupo() {
      console.log("qweqwe");
      this.$data.loadingCreaFamiliarButton = true;
      try {
        const res = await FamiliaService.crearFamilia({
          aceptaSolicitudes: true,
          dni: localStorage.getItem("dni"),
          familiaNombre: this.$data.grupoFamiliar,
        });

          this.$data.loadingCreaFamiliarButton = false;
        
        console.log(res);
      } catch (error) {
        console.log(error);
        this.$data.loadingCreaFamiliarButton = false;
        this.$data.errorFlagModal = true;
      }
    },
    unirseGrupo() {
      console.log("unirse gurpo");
    },
    cerrarModal() {
      this.$data.errorFlagModal = false;
    },
  },
};
</script>

<style>
.home-container .field-container {
  margin: 128px 0 160px 0;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
.home-container .field-container input {
  text-align: center;
}

.home-container .grupo-familiar-label {
  text-align: center;
}
.home-container__list-button {
  width: 80%;
  margin: 0 auto;
  display: flex;
  justify-content: space-around;
  align-items: center;
}
</style>
