<template>
  <div class="card-container-request">
    <div class="card-container-request__title">
        <h3>{{request.familyName}}</h3>
    </div>
    <div class="card-container-request__description">
      <p class="card-container-request__description__info">Solicitud enviada</p>
      <p color-rojo class="card-container-request__description__status">Pendiente</p>
    </div>
    <div class="card-container-request__button">
      <button-shared
        :bgColor="'red'"
        :text="'Cancelar'"
        :type="'small'"
        @Event="cancelarSolicitud"
      ></button-shared>
    </div>
  </div>
</template>

<script>
import ButtonShared from "../../../shared/button/button.component.vue";
import UsuarioService from "../../core/services/usuario.service";
export default {
  name: "RequestCard",
  components: { ButtonShared },
  props: ["request"],


methods: {
    async cancelarSolicitud() {
      this.UsuarioService.cancelarSolicitud(this.$data.dni. this.$data.idFamilia);
      }
 }
};


</script>

<style>


.card-container-request{
  width: 264px;
  margin: 0 auto 12px;
  background: #fafafa;
  position: relative;
}

.card-container-request__title{
  margin: 18px 0 24px 0;
  width: 100%;
}
.card-container-request__title h3{
  font-size: 20px;
  font-weight: 600;
  color: #000;
  text-align: center;
}

.card-container-request p{
  text-align: center;
  width: 100%;
}
.card-container-request__description__info{
  font-size: 16px;
  color: #535353;
  margin: 0 0 4px 0;
}

.card-container-request__description__status{
  font-size: 14px;
  font-weight: 600;
}

.card-container-request__button{
  width: 100%;
  display: flex;
  justify-content: center;
  margin: 32px 0 24px 0;
}






</style>
