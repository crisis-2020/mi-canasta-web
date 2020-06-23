<template>
  <div class="member-container">
    <div class="member-container__information">
      <div class="member-container__roles">
          <img v-if="this.$data.rolPerfilId == 3" src="../../../assets/ic_crown.svg" alt="" >
          <img v-else src="../../../assets/ic_shop-cart.svg" alt=""  >

      </div>
      <div class="member-container__personal">
        <h2>{{ person.nombre }}</h2>
        <p>{{ person.dni }}</p>
      </div>
    </div>

    <div class="member-container__select">
      <select-shared :options="data"/>
    </div>
  </div>
</template>

<script>
import SelectShared from "../select/Select.component.vue";
import UsuarioService from "../../core/services/usuario.service";

export default {
  name: "MembersCardShared",
  components: {SelectShared},
  props: [
    'person',
    'dni',
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
      data: ["Administrador", "Responsable de Ventas"],
    }
  },
  created(){
    this.getRolUsuario();
    this.$data.rolPerfilId = this.$route.rolUsuario;
  },
  
  methods:{

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
          if(rolesAux[i].rolPerfilId == 3) cont++;
        }
        if(cont > 0) return true;
        else return false;
      }
      catch (error) {
        console.log(error);        
      }
    },


    async getRolUsuario(){
       try {
        const res = await UsuarioService.getUsuario(localStorage.getItem("dni"));
        this.roles = res.data.rolUsuarios;
        for(let i=0; i < this.roles.length; i++){
          if(this.roles[i].rolPerfilId == 3); 
        }        
      }
      catch (error) {
        console.log(error);        
      }
    },
  },
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
