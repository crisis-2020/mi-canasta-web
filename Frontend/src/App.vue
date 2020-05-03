<template>
  <router-view></router-view>
</template>

<script>

export default {
  name: 'App',

}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600;700&display=swap');
*{
  padding: 0;
  margin: 0;
  box-sizing: border-box;
  list-style: none;
  text-decoration: none;
  font-family: 'Montserrat', sans-serif;
  outline: none;
}
#app {

}

.input-shared-container{
  display: flex;
  flex-direction: column;
}
.label-shared-component {
    font-size: 14px;
    font-weight: 600;
    color: #7A7A7A;
    margin-bottom: 10px;
    width: 100%;
}

.input-shared-component{
  width: 264px;
    border: none;
    background: #FAFAFA;
    color: #000000;
    font-size: 16px;
    font-weight: 400;
    padding: 16px;
    border-radius: 4px;
}
</style>
