<template>
  <div class="application-container">
    <div class="mobile-container">
      <HeaderComponent></HeaderComponent>
      <router-view></router-view>
      <FooterComponent></FooterComponent>
    </div>
  </div>
</template>

<script>
import FooterComponent from "../footer/Footer.vue";
import HeaderComponent from "../header/Header.vue";
export default {
  name: "LayoutPage",
  components: { FooterComponent, HeaderComponent },
};
</script>

<style>
.application-container {
  width: 100%;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background: #f76a8c;
}

.mobile-container {
  width: 360px;
  height: 640px;
  background: #ffffff;
  box-shadow: 0 3px 45px 12px rgba(40,40,40,0.1);
  border-radius: 8px;
  overflow: hidden;
  position: relative;
}
</style>
