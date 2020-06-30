<template>
    <div class="user-edit-container">
        <div class="field-container margin">
            <img class = "image-back" src="../../../assets/ic_back.svg" alt=""
            v-on:click="volver">
            <h1 class="user-edit-container__header h1">
                Editar información
            </h1>
            <div class="user-edit-container__form-container">
                <div class="input-shared-container">
                    <label>Correo</label>
                    <input
                        class="input-shared-component"
                        v-model="correo"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Contraseña Actual</label>
                    <input
                        type="password"
                        class="input-shared-component"
                        v-model="contrasena"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Nueva contraseña</label>
                    <input
                        class="input-shared-component"
                        type="password"
                        placeholder="Opcional"
                        v-model="nuevaContrasena"
                    />
                </div>
                <div class="input-shared-container">
                    <label>Repetir contraseña</label>
                    <input
                        class="input-shared-component"
                        type="password"
                        placeholder="Opcional"
                        v-model="repetirContrasena"
                    />
                </div>
                <div class="user-edit-container__button">
                    <ButtonShared
                    class="user-edit-button"
                    :text="'Actualizar'"
                    :type="'large'"
                    :bgColor="'red'"
                    :loading="loadingButton"
                    :disabled="contrasena.length < 1"
                    @Event="putUsuario"
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

import { UsuarioGet } from '../../core/model/usuario.model';
import UsuarioService from '../../core/services/usuario.service';
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";

    export default {
        name: "UserEditPage",
        components: { ButtonShared, ErrorModalShared },

        data: function() {
            return {
                correo:"",
                contrasena:"",
                nuevaContrasena: "",
                repetirContrasena: "",
                user: UsuarioGet,
                loadingButton: false,
                isShowModal: false,
                modalDescription: "",
                modalTitle: "",
            }
        },

        created(){
            this.getUsuario();            
        },

        methods:{

            async getUsuario(){
                try {
                    const res = await UsuarioService.getUsuario(localStorage.getItem("dni"));
                    this.user = res.data;
                    this.correo = this.user.correo;  
                }
                catch (error) {
                    console.log(error);        
                }
            },

            async putUsuario(){
                this.loadingButton = true;
                try {
                    await UsuarioService.putUsuario(localStorage.getItem("dni"), {
                        correo: this.correo,
                        contrasena: this.contrasena,
                        nuevaContrasena: this.nuevaContrasena,
                        repetirContrasena: this.repetirContrasena,
                    });
                    this.loadingButton = false;
                    this.modalTitle="Éxito";
                    this.modalDescription="Se realizó la actualización de datos";
                    this.isShowModal = true;
                }
                catch (error) {
                    this.loadingButton = false;
                    if (error.response.data.exception === "ActualPasswordNotMatchException" ||
                    error.response.data.exception === "NewPasswordNotMatchException" ||
                    error.response.data.exception === "EmailWrongFormatException"){
                        this.modalDescription = error.response.data.message;
                        this.modalTitle = "Error"
                        this.isShowModal = true;
                    }
                    console.log(error);
                }
            },

            volver(){
                this.$router.push("/family/user");
            },

            closeModal() {
                this.isShowModal = false;
                // location.reload();
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