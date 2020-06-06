<template>
  <div class="family-container">
    <div class="family-container__title">
      <h2>Participantes</h2>
    </div>
    <div class="family-container__enable-request">
      <p>Desactivar solicitudes</p>
          <a-switch default-checked @change="onChange" />

    </div>

    <div class="family-container__list-members">
        <members-card-shared :person=user v-for="(user,i) in mock" v-bind:key="i"/>
    </div>
  </div>
</template>

<script>
import MembersCardShared from "../../shared/members/members.component.vue";
export default {
  name: "HomeFamilyPage",
  components: {MembersCardShared},

  mounted(){
    console.log(this.$route.params.id);
  },
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
          roles: [ "Comprador"],
          categorias: ["Alimentos"],
        },
      ],
    };
  },
  methods: {
    onChange(){
      console.log("qwe");
    }
  }
};
</script>

<style>
.family-container{
    margin: 0 32px;
}
.family-container__title{
  margin: 24px 0;
}
.family-container__title h2{
    font-size: 20px;
    font-weight: 600;
    color: #000;
}
.family-container__enable-request p{
  margin: 0 0 8px 0;
  font-size: 16px;
}
</style>
