<template>
  <a-select
    mode="unique"
    :size="'large'"
    placeholder="Asignar nuevo rol"
    style="width: 100%"
    @change="handleChange" >
    <a-select-option v-for="item in options" :key="item">
      {{ item }}
    </a-select-option>
  </a-select>
</template>

<script>
import UsuarioService from "../../core/services/usuario.service";
import FamiliaService from "../../core/services/familia.service";
import { UsuarioGet } from '../../core/model/usuario.model';

export default {
  name: "SelectShared",
  props: ["options"],

  created() {
    this.$data.idFamilia = this.$route.params.id;
  },

  data: function(){
    return { 
      roles: [],
      miembros: [ ],
      user: UsuarioGet,
      value: ["Comprador, Administrador"], size: "default" };
  },

  methods: {

    async listarMiembrosDeFamilia(){
      for(let i = 0; i < this.numIntegrantes; i++){
        const res = await FamiliaService.listarMiembrosDeFamilia(this.$data.idFamilia);
        this.user = res.data;
        this.dni = this.user.dni;
        //UsuarioService.cambiarRolUsuario(this.dni);
      }
    },


    handleChange(value) {
    try{
      //UsuarioService.cambiarRolUsuario(localStorage.getItem("dni"));
      let data = JSON.parse(localStorage.getItem("data"));
      UsuarioService.cambiarRolUsuario(data.usuario.usuario.dni);
      console.log(`Selected: ${value}`);
      this.$router.go();
    } catch (error){
      console.log(error);
    }
    },

  },
};
</script>

<style></style>
