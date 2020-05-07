<template>
  <button 
    v-bind:disabled="disable || false"
  v-on:click="cb()"
  class="btn-shared-component"
  :class="[
  {'large': type==='large'},
  {'small': type==='small'},
  {'red': bgColor ==='red'},
  {'yellow': bgColor==='yellow'}
  ]"
  >
  <span v-if="!loading">{{text}}</span>
  <LoadingButtonShared v-if="loading"></LoadingButtonShared>
  
  </button>
</template>

<script>
import LoadingButtonShared from "../loading/loading-button.component.vue";
export default {
    name: "ButtonShared",
    components: {LoadingButtonShared},
    props: [ 'text', 'type','bgColor','loading','disable'],
    methods: {
        cb: function(){
           this.$emit('Event')
        }
    }
}
</script>

<style>
.btn-shared-component{
    border-radius: 6px;
    border: none;
    color: #ffffff;
    padding: 12px 32px;
    font-size: 18px;
    text-align: center;
    cursor: pointer;
    font-weight: 600;
    display: flex;
    align-items: center;
    justify-content: center;
}
.large{
    width: 224px;

}
.small{
    width: fit-content;
}
.red{
    background: #FF5A82;
}
.yellow{
    background: #F8DC88;
}


</style>