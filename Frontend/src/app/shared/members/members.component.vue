<template>
  <div class="member-container">
    <div class="member-container__information">
      <div class="member-container__roles">
          <!-- <img v-if="person.roles.includes('Admin')" src="../../../assets/ic_crown.svg" alt="">
          <img v-if="person.roles.includes('Comprador')" src="../../../assets/ic_shop-cart.svg" alt=""> -->
          <img  src="../../../assets/ic_crown.svg" alt="">
          <img  src="../../../assets/ic_shop-cart.svg" alt="">

      </div>
      <div class="member-container__personal">
        <h2>{{ person.nombre }}</h2>
        <p>{{ person.dni }}</p>
      </div>
      <div class="member-container__delete-btn">
          <button>Remover</button>
      </div>
    </div>

    <div class="member-container__select">
      <select-shared :options="data"/>
    </div>
  </div>
</template>

<script>
import SelectShared from "../select/Select.component.vue";
export default {
  name: "MembersCardShared",
  components: {SelectShared},
  props: ['person'],
  data:function(){
    return{
      data: ["Administrador", "Comprador"]
    }
  }
};
</script>

<style>
.member-container{
    display: flex;
    width: 100%;
    margin: 32px 0;
    flex-direction: column;
}

.member-container__information{
    display: flex;
    width: 100%;
}
.member-container__roles{
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: flex-start;
    padding-top: 4px;
}
.member-container__roles img{
    margin-bottom: 8px;
}
.member-container__personal{
    margin-left: 16px;
    width: 75%;
}
.member-container__personal h2{
    font-size: 16px;
    font-weight: 600;
    margin: 0;
}

.member-container__personal p{
    font-size: 14px;
    font-weight: 400;
    color: #545454;
    margin-top: 2px;
    
}
.member-container__delete-btn button{
    padding: 10px 14px;
    background: rgba(247, 106, 140, .21);
    color: rgba(247, 106, 140, 1);
    border: none;
    border-radius: 6px;
    font-weight: 600;
}

</style>
