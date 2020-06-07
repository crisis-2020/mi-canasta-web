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


*[color-rojo]{
  color: #F76A8C;
}
*[color-verde]{
  color: #CCF0E1;
}

*[color-amarillo]{
  color : #F8FAB8;
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
button:disabled{
  opacity: .3;
  cursor: not-allowed;
}
button{
  cursor: pointer;
  transition: all .2s ease-in-out;
}
/* width */
::-webkit-scrollbar {
  width: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  border-radius: 10px;
}
 
/* Handle */
::-webkit-scrollbar-thumb {
  background: #dedede; 
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #d1d1d1; 
}
.ant-switch-checked{
  background: #F76A8C !important;
}

.ant-slider-track{
  background-color: #F8DC88 !important;
}
.ant-slider-handle{
      border: solid 2px #F8DC88 !important;
}
.ant-slider-dot-active{
  border-color: #F8DC88 !important;
}
</style>
