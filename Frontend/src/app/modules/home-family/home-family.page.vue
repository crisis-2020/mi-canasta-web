<template>
  <div class="family-container">
    <div class="family-container__title">
      <h2>Participantes</h2>
    
    <div class="family-container__enable-request">
      <div v-if="aceptaSolicitudes" :value="false" >
      <p> La familia acepta solicitudes </p> </div> 
      <div v-else>
      <p> La familia no acepta solicitudes </p> </div> 
      <a-switch v-model="aceptaSolicitudes" @change="onChange" />

    <div class="family-container__list-members">
      <members-card-shared
        :person="user"
        :nombreFamilia="nombreFamilia"
        :idFamilia="idFamilia"
        :dni="user.dni"
        :userIsAdmin="userIsAdmin"
        :numIntegrantes = "numIntegrantes"
        :unicoAdmin = "unicoAdmin"
        v-for="(user, i) in miembros"
        v-bind:key="i" />  
    </div>
        </div>
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
      numIntegrantes: 0,
      unicoAdmin: false,
      rol: false,
    };
  },

  methods: {
    onChange() {
      try{
        FamiliaService.desactivarSolicitud(this.$data.idFamilia);
      console.log(this.$data.idFamilia);
      } catch (error){
        console.log(error);
      }
    },

    async isUnicoAdmin(){
      let cont = 0;
      for(let i = 0; i < this.numIntegrantes; i++){
          if(await this.isAdmin(this.miembros[i].dni) == true) cont++;
      }
      if(this.userIsAdmin == true && cont == 1) this.unicoAdmin = true;
    },

    async isAdmin(dniIntegrante){
      let cont = 0;
      let rolesAux;
      try {
        const res = await UsuarioService.getUsuario(dniIntegrante);
        rolesAux = res.data.rolUsuarios;
        for(let i = 0; i < rolesAux.length; i++){
          if(rolesAux[i].rolPerfilId == 1) cont++;
        }
        if(cont > 0) return true;
        else return false;
      }
      catch (error) {
        console.log(error);        
      }
    },

    async listarFamilia() {
      try {
        const result = await FamiliaService.listarFamilia(this.$data.idFamilia);

        this.$data.nombreFamilia = result.data.nombre;
        this.$data.aceptaSolicitudes =  result.data.aceptaSolicitudes;
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
        this.numIntegrantes = this.$data.miembros.length;
        this.isUnicoAdmin();
      } catch (error) {
        console.log(error);
      }
    },

    async getRolUsuario(){
       try {
        let data = JSON.parse(localStorage.getItem("data"));
        const res = await UsuarioService.getUsuario(data.usuario.usuario.dni);
        this.roles = res.data.rolUsuarios;
        for(let i=0; i < this.roles.length; i++){
          if(this.roles[i].rolPerfilId == 1) {
            this.userIsAdmin=true;
          }else{
            this.userIsAdmin=false;
          }
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
  padding: 0 32px;
  height: calc(640px  - 128px);
  overflow: auto;
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
