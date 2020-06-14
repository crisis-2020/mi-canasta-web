<template>
  <div class="family-container">
    <div class="family-container__title">
      <h2>Participantes</h2>
    </div>
    <div class="family-container__enable-request">
      <div v-if="aceptaSolicitudes" :value="false" >
      <p> La familia acepta solicitudes </p> </div> 
      <div v-else>
      <p> La familia no acepta solicitudes </p> </div> 
      <a-switch v-model="aceptaSolicitudes" @change="onChange" />
    </div>

    <div class="family-container__list-members">
      <members-card-shared
        :person="user"
        :nombreFamilia="nombreFamilia"
        :idFamilia="idFamilia"
        :dni="user.dni"
        :userIsAdmin="userIsAdmin"
        v-for="(user, i) in miembros"
        v-bind:key="i"
      />
    </div>
  </div>
</template>

<script>
import MembersCardShared from "../../shared/members/members.component.vue";
import FamiliaService from "../../core/services/familia.service";
import UsuarioService from "../../core/services/usuario.service";
export default {
  name: "HomeFamilyPage",
  components: { MembersCardShared },


  created() {
    this.getRolUsuario();
    this.$data.idFamilia = this.$route.params.id;
    this.listarFamilia();
  },

  data: function() {
    return {
      idFamilia: -1,
      nombreFamilia: "",
      aceptaSolicitudes: false,
      miembros: [ ],
      roles: [],
      userIsAdmin: false,
    };
  },

  methods: {
    onChange() {
      FamiliaService.desactivarSolicitud(this.$data.idFamilia);
      console.log(this.$data.idFamilia);
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

    async getRolUsuario(){
      console.log("Obtener Rol del Usuario Logeado");
       try {
        const res = await UsuarioService.getUsuario(localStorage.getItem("dni"));
        this.roles = res.data.rolUsuarios;
        console.log(res);
        for(let i=0; i < this.roles.length; i++){
          if(this.roles[i].rolPerfilId == 1) this.userIsAdmin=true;
          console.log(this.userIsAdmin);
        }        
      }

      catch (error) {
        console.log(error);        
      }
    },
    cerrarModal() {
      this.errorFlagModal = false;
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
