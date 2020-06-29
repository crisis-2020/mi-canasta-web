<template>
    <div class="user-edit-container">
        <div class="field-container margin">
            <img class = "image-back" src="../../../assets/ic_back.svg" alt=""
            v-on:click="volver">
            <h1 class="user-edit-container__header h1">
                Editar Información Tienda
            </h1>
            <div class="user-edit-container__form-container">
                <div class="input-shared-container">
                    <label>Nombre de Tienda</label>
                    <input
                        class="input-shared-component"
                        v-model="descripcion"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Latitud</label>
                    <input
                        class="input-shared-component"
                        v-model="latitud"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Longitud</label>
                    <input
                        class="input-shared-component"
                        v-model="longitud"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Horario</label>
                    <input
                        class="input-shared-component"
                        placeholder="Ingrese su nuevo horario"
                        v-model="horario"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Validar contraseña</label>
                    <input
                        class="input-shared-component"
                        type="password"
                        v-model="contrasena"
                    />
                </div>
                <div class="user-edit-container__button">
                    <ButtonShared
                    class="user-edit-button"
                    :text="'Actualizar'"
                    :type="'large'"
                    :bgColor="'red'"
                    :loading="loadingButton"
                    :disabled="contrasena.length < 3"
                    @Event="putTienda"
                    />
                </div>
            </div>
        </div>
        <ErrorModalShared
            @Event="closeModal"
            v-if="isShowModal"
            :title="modalTitle"
            :description="modalDescription"
        ></ErrorModalShared>

    </div>
</template>

<script>

import { TiendaGet } from '../../core/model/tienda.model';
import TiendaService from '../../core/services/tienda.service';
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";

    export default {
        name: "UserEditPage",
        components: { ButtonShared, ErrorModalShared },

        created(){
            this.$data.idTienda = this.$route.params.id;
            this.listarTienda();            
        },

        data: function() {
            return {
                idTienda: -1,
                descripcion:"",
                direccion:"",
                latitud:"",
                longitud:"",
                horario:"",
                contrasena:"",
                tienda: TiendaGet,
                loadingButton: false,
                isShowModal: false,
                modalDescription: "",
                modalTitle: "",
            }
        },

        methods:{

            async listarTienda(){
                try {
                    const res = await TiendaService.listarTienda(this.$data.idTienda);
                    this.tienda = res.data;
                    this.descripcion = this.tienda.descripcion;  
                    this.latitud = this.tienda.latitud;
                    this.longitud = this.tienda.longitud;
                    console.log("777");
                }
                catch (error) {
                    console.log(error);        
                }
            },

            async putTienda(){
                this.loadingButton = true;
                try {
                    await TiendaService.putTienda(this.$data.idTienda, localStorage.getItem("dni"), {
                        descripcion: this.descripcion,
                        direccion: this.direccion,
                        latitud: this.latitud,
                        longitud: this.longitud,
                        horario: this.horario,
                        contrasena: this.contrasena,
                    });
                    this.loadingButton = false;
                    this.modalTitle="¡Listo!";
                    this.modalDescription="Se realizó la actualización de datos en la tienda";
                    this.isShowModal = true;
                    this.$router.push("/home/user");
                }
                catch (error) {
                    this.loadingButton = false;
                    if (error.response.data.exception === "ActualPasswordNotMatchException"){
                        this.modalDescription = error.response.data.message;
                        this.modalTitle = "¡Error!"
                        this.isShowModal = true;
                    }
                    console.log(error);
                }
            },

            volver(){
                this.$router.push("/home/user");
            },

            closeModal() {
                this.isShowModal = false;
                location.reload();
            },
        }
    }
</script>

<style>

.field-container {
    margin: 0px 40px 0px 40px;
    display: flex;
    flex-direction: column;
    position: relative;
}

.user-edit-container h1 {
    justify-content: right;
    align-items: right;
    font-size: 20px;
    font-weight: 700;
    margin: 12px 0 8px 0;
}

.user-edit-container__form-container {
    justify-content: center;
    align-items: center;
    display: flex;
    flex-direction: column;
    margin-top: 6px;
    height: calc(640px  - 207px);
    overflow: auto;
}

.user-edit-container__button {
    justify-content: center;
    align-items: center;
    margin: auto auto auto auto
}

.user-edit-button {
    margin: 12px auto 0 auto;
}

.input-shared-container {
  margin-bottom: 14px;
}

.image-back {
    display: block;
    float: left;
    width: 25px;
    height: 25px;
    margin-right: 6px;
    margin-top: 6px;
}

</style>