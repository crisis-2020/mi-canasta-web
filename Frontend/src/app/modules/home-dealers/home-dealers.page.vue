<template>
  <div class="dealers-container">
    <div class="dealers-container__members-quantity">
      <img src="../../../assets/ic_members.svg" alt="members" />
      <p color-rojo>10/15</p>
    </div>
    <div class="dealers-container__title">
      <h2>Lista de distribuidores</h2>
    </div>

    <div class="dealers-container__add">
      <button>
        <img src="../../../assets/ic_plus.svg" alt="plus" />
      </button>
      <div class="input-shared-container">
        <input
          class="input-shared-component"
          type="text"
          placeholder="Ingrese un dni"
          maxlength="8"
        />
      </div>
    </div>

    <div class="dealers-container__list">
      <members-card-shared
        v-for="person in mock"
        v-bind:key="person"
        :person="person"
      ></members-card-shared>
    </div>
  </div>
</template>

<script>
import MembersCardShared from "../../shared/members/members.component.vue";
export default {
  components: { MembersCardShared },
  name: "HomeDealersPage",
  data: function() {
    return {
      mock: [
        {
          name: "Anthony",
          dni: "10101010",
          roles: ["Admin", "Comprador"],
          categorias: ["Mercancia"],
        },
        {
          name: "Jimena",
          dni: "1245789",
          roles: ["Comprador"],
          categorias: ["Alimentos"],
        },
      ],
    };
  },
};
</script>

<style>
.dealers-container{
    padding: 0 32px;
    height: calc(640px  - 128px);
    overflow: auto;
}

.dealers-container__members-quantity{
    display: flex;
    align-items: center;
    margin-top: 32px;
}
.dealers-container__members-quantity p {
    font-size: 18px;
    font-weight: 600;
    margin: 0 0 0 6px;
}
.dealers-container__title{
    margin-top: 24px;
}
.dealers-container__title h2{
    font-weight: 600;
    color: #000;
    margin: 0;
}

.dealers-container__add{
    margin-top: 32px;
    display: flex;
    justify-content: center;
    flex-direction: column;
}
.dealers-container__add button{
    margin: 0 auto;
    width: 40px;
    height: 40px;
    display: flex;
    justify-content: center;
    align-items: center;
    border: none;
    cursor: pointer;
    border-radius: 4px;
    background: #F76A8C;
}

.dealers-container__add > div{
    margin-top: 32px;
}

.dealers-container__add input{
    text-align: center;
}

</style>
