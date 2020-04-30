<template>
  <div>
    <h2>Soy el login</h2>
    <p>{{asd}}</p>
    <ComponenteLogin></ComponenteLogin>
  </div>
</template>

<script>
import ComponenteLogin from "./components/login/login.component.vue";
export default {
  name: "LoginPage",
  components: { ComponenteLogin },

  data: function(){
    return{
      asd: "123"
    }
  },

};
</script>

<style></style>
