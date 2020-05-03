<template>
  <div class="application-container">
    <div class="mobile-container">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>

export default {
  name: "LayoutLogin",
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
