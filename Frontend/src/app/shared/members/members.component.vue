<template>
  <div class="member-container"
  
  >
    <div class="member-container__information">
      <div class="member-container__roles">
          <img v-if="person.rolPerfilId == 1" src="../../../assets/ic_crown.svg" alt="">
          <img v-if="person.rolPerfilId == 2" src="../../../assets/ic_shop-cart.svg" alt="">
      </div>

      <div class="member-container__personal">
        <h2>{{ person.nombre +" "+ person.apellidoPaterno}}</h2>
        <p>{{ person.dni }}</p>
      </div>
      <div class="member-container__delete-btn">
        
      <button
          v-on:click="abrirModalConfirmacion"
          >Remover</button>
      </div>
    </div>

    <div class="member-container__select">
      <select-shared :options="data"/>
    </div>

    <ConfirmationModalShared
      @YesEvent="deleteUsuarioFromFamilia"
      @NoEvent="cerrarModalConfirmacion"
      v-if="isShowConfirmationModal"
      :title="'Confirmación'"
      :description="descriptionConfirmModal"
    ></ConfirmationModalShared>

    <ErrorModalShared
      v-if="errorFlagModal"
      :title="'Lo sentimos'"
      :description="descriptionErrorModal"
      @Event="cerrarModal"
    ></ErrorModalShared>
  </div>
</template>

<script>
import SelectShared from "../select/Select.component.vue";
import FamiliaService from "../../core/services/familia.service";
import UsuarioService from "../../core/services/usuario.service";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";
import ConfirmationModalShared from "../../shared/modal/confirmation-modal.component.vue";

export default {
  name: "MembersCardShared",
  components: {SelectShared, ErrorModalShared, ConfirmationModalShared},
  props: [
    'person',
    'dni',
    'nombreFamilia',
    'idFamilia',
    'userIsAdmin',
    'numIntegrantes',
    'unicoAdmin',
    ],
  data:function(){
    return{
      roles: [],
      errorFlagModal: false,
      userToDeleteIsAdmin: false,
      isShowConfirmationModal: false,
      descriptionErrorModal: "",
      descriptionConfirmModal: "",
      data: ["Administrador", "Comprador"],
    }
  },
  created(){
    this.getRolUsuario();
  },
  methods: {

    deleteUsuarioFromFamilia(){
      if( localStorage.getItem("dni") == this.dni ){
        this.deleteYo();
      }
      else {
        this.deleteOtroUsuario();
      }
    },

    async deleteYo(){
      try {
        if(this.numIntegrantes > 1 && this.unicoAdmin == true){
          this.descriptionErrorModal = "Debe asignar otro administrador para poder salir del grupo familiar";
          this.errorFlagModal = true;
          this.cerrarModalConfirmacion();
        }
        else {
         await FamiliaService.deleteUsuariofromFamilia(this.nombreFamilia, this.dni);
          this.$router.push("/home");
        }
      }
      catch (error) {
        console.log(error);        
      }
    },

    async deleteOtroUsuario(){
     try {
      if(this.userIsAdmin == true){
        if(this.userToDeleteIsAdmin == true){
          this.descriptionErrorModal = "No puede eliminar a un administrador";
          this.errorFlagModal = true;
          this.cerrarModalConfirmacion();
        }
        else{
          FamiliaService.deleteUsuariofromFamilia(this.nombreFamilia, this.dni);
          location.reload();
        }
      }
      else {
        this.descriptionErrorModal = "No se cuenta con privilegios de administrador";
        this.errorFlagModal = true;
        this.cerrarModalConfirmacion();
      }
    }
    catch (error) {
      console.log(error);        
    }
  },

    async getRolUsuario(){
       try {
        const res = await UsuarioService.getUsuario(this.dni);
        this.roles = res.data.rolUsuarios;
        for(let i=0; i < this.roles.length; i++){
          if(this.roles[i].rolPerfilId == 1) {
            this.userToDeleteIsAdmin=true;
          } else {
            console.log("roles");
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

    abrirModalConfirmacion(){
      if(localStorage.getItem("dni") == this.dni ){
        if(this.numIntegrantes == 1)
          this.descriptionConfirmModal="¿Desea abandonar el grupo familiar? Toda la información de la familia se perderá";
        else this.descriptionConfirmModal="¿Desea abandonar el grupo familiar?";
      }
      else {
        this.descriptionConfirmModal="¿Desea eliminar al usuario seleccionado?";
      }
      this.isShowConfirmationModal=true;
    },
    cerrarModalConfirmacion(){
      this.isShowConfirmationModal=false;
    }
  }
};
</script>

<style>
.member-container{
    display: flex;
    width: 100%;
    margin: 32px 0;
    flex-direction: column;
}

.member-container__information{
    display: flex;
    width: 100%;
}
.member-container__roles{
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: flex-start;
    padding-top: 4px;
}
.member-container__roles img{
    margin-bottom: 8px;
}
.member-container__personal{
    margin-left: 16px;
    width: 75%;
}
.member-container__personal h2{
    font-size: 16px;
    font-weight: 600;
    margin: 0;
}

.member-container__personal p{
    font-size: 14px;
    font-weight: 400;
    color: #545454;
    margin-top: 2px;
    
}
.member-container__delete-btn button{
    padding: 10px 14px;
    background: rgba(247, 106, 140, .21);
    color: rgba(247, 106, 140, 1);
    border: none;
    border-radius: 6px;
    font-weight: 600;
}

</style>
