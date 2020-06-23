<template>
  <a-select
    mode="unique"
    :size="'large'"
    placeholder="Seleccione el rol"
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
    return { value: ["china"], size: "default" };
  },
  methods: {
    handleChange(value) {
      console.log(`Selected: ${value}`);
    },
  },
};
</script>

<style></style>
