<template>
    <div class="solicitud-container">
        <div class="field-container margin">
            <img src="../../../assets/send.png" alt="">
            <h1 class="h1-shared-component solicitud-enviada-h1">
                Solicitud Enviada
            </h1>
            <label class="label-shared-component solicitud-enviada-label">
                Su solicitud para unirse al grupo familiar se ha realizado con éxito
            </label>
            <br><br><br><br>
            <div class="solicitud-container__list-button">
                <ButtonShared
                    class="login-container__button"
                    :text="'Volver a Inicio'"
                    :type="'large'"
                    :bgColor="'red'"
                    :loading="loading_button1"
                    @Event="event"
                ></ButtonShared>
            </div>
        </div>
    </div>
</template>

<script>
    import ButtonShared from "../../shared/button/button.component.vue";
    export default {
        name: "SolicitudPage",
        components: {
            ButtonShared,
        },
        data: function() {
            return {
                loading_button1: false,
            }
        },
        methods: {
            event() {
                this.$data.loading_button1 = true;
            },
        }
    }
</script>

<style>

.solicitud-container .field-container {
  margin: 108px 40px 160px 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  
}
.solicitud-container .field-container input {
  text-align: center;
}

.solicitud-container .solicitud-enviada-h1 {
  text-align: center;
  color: #F76A8C;
  font-size: 20px;
  font-weight: bold;
}

.solicitud-container .solicitud-enviada-label {
  text-align: center;
}

.solicitud-container__list-button {
  width: 80%;
  margin: 0 auto 0 auto;
  display: flex;
  justify-content: space-around;
  align-items: center;
}

.solicitud-container__button {
  margin-top: 24px;
}
</style>