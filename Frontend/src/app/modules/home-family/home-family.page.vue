<template>
  <div class="family-container">
    <div class="family-container__title">
      <h2>Participantes</h2>
    </div>
    <div class="family-container__enable-request">
      <p>Desactivar solicitudes</p>
      <a-switch v-model="aceptaSolicitudes" @change="onChange" />
    </div>

    <div class="family-container__list-members">
      <members-card-shared
        :person="user"
        :idFamilia="idFamilia"
        v-for="(user, i) in miembros"
        v-bind:key="i"
      />
    </div>
  </div>
</template>

<script>
import MembersCardShared from "../../shared/members/members.component.vue";
import FamiliaService from "../../core/services/familia.service";
export default {
  name: "HomeFamilyPage",
  components: { MembersCardShared },

  created() {
    this.$data.idFamilia = this.$route.params.id;

    this.listarFamilia();
  },
  data: function() {
    return {
      idFamilia: -1,
      nombreFamilia: "",
      aceptaSolicitudes: false,
      miembros: [ ],
      mock: [
        {
          name: "Anthony",
          dni: "10101010",
          roles: ["Admin", "Comprador"],
          categorias: ["Mercancia"],
        },
        {
          name: "Jimena",
          dni: "1245789",
          roles: ["Comprador"],
          categorias: ["Alimentos"],
        },
      ],
    };
  },
  methods: {
    onChange() {
      console.log("qwe");
    },

    async listarFamilia() {
      try {
        const result = await FamiliaService.listarFamilia(this.$data.idFamilia);

        this.$data.nombreFamilia = result.data.nombre;
        this.$data.aceptaSolicitudes =  result.data.aceptaSolicitudes;
        console.log(this.$data.nombreFamilia);
        this.listarMiembros();
      } catch (error) {
        console.log(error);
      }
    },

    async listarMiembros() {
      try {
        const result = await FamiliaService.listarMiembrosDeFamilia(
          this.$data.nombreFamilia
        );
        this.$data.miembros  = result.data;
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style>
.family-container {
  margin: 0 32px;
}
.family-container__title {
  margin: 24px 0;
}
.family-container__title h2 {
  font-size: 20px;
  font-weight: 600;
  color: #000;
}
.family-container__enable-request p {
  margin: 0 0 8px 0;
  font-size: 16px;
}
</style>
