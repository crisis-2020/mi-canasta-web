<template>
  <a-select
    mode="unique"
    :size="'large'"
    placeholder="Asignar nuevo rol"
    style="width: 100%"
    @change="handleChange"
  >
    <a-select-option v-for="item in options" :key="item">
      {{ item }}
    </a-select-option>
  </a-select>
</template>

<script>
import FamiliaService from '../../core/services/familia.service';
import UsuarioService from "../../core/services/usuario.service";

export default {
  name: "SelectShared",
  props: ["options"],

  created() {
    this.$data.idFamilia = this.$route.params.id;
  },

  data() {
    return { 
      value: ["Comprador, Administrador"], size: "default" };
  },
  methods: {
    handleChange(value) {
    try{
      let data = JSON.parse(localStorage.getItem("data"));
      UsuarioService.getUsuario(data.usuario.usuario.dni);
      FamiliaService.asignarRolUsuario(data.usuario.familia.familiaId,
      data.usuario.usuario.dni);
      console.log(`Selected: ${value}`);
      // this.$router.go();
    } catch (error){
      console.log(error);
    }
    },
  },
};
</script>

<style></style>
