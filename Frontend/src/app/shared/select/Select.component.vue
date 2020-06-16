<template>
  <a-select
    mode="multiple"
    :size="'large'"
    placeholder="Asignar nuevo rol"
    :default-value="['Administrador']"
    style="width: 100%"
    @change="handleChange"
  >
    <a-select-option v-for="item in options" :key="item">
      {{ item }}
    </a-select-option>
  </a-select>
</template>

<script>
export default {
  name: "SelectShared",
  props: ["options"],
  data() {
    return { value: ["Comprador"], size: "default" };
  },
  methods: {
    handleChange(value) {
      try{
        this.FamiliaService.asignarRolUsuario(this.nombreFamilia, this.dni);
        console.log(`Selected: ${value}`);
      }catch (error){
        this.descriptionErrorModal = "No se puede cambiar de rol";
      }
    },
  },
};
</script>

<style></style>
