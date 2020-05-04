<template>
  <div class="input-shared-component">
      <p
        :class="[
        
            {'label-left': labelAlign === 'left'},
            {'label-center': labelAlign === 'center'}
        ]"
      
      >{{labelText}}</p>
      <input type="text" v-model="model">
  </div>
</template>

<script>
export default {
    name: 'InputShared',
    props: ['labelText','model', 'labelAlign']
}
</script>

<style>

.label-left{
    text-align: left;
}

.label-center{
    text-align: center;
}
</style>