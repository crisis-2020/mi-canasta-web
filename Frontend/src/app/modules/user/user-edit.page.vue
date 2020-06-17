<template>
    <div class="user-edit-container">
        <div class="user-edit-container__form-container">
                <h1 class="user-edit-container__header h1">Editar información</h1><br>
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
                    class="input-shared-component"
                    v-model="contrasena"
                />
            </div>
            <div class="input-shared-container">
                <label>Nueva contraseña</label>
                <input
                    class="input-shared-component"
                    v-model="nuevaContrasena"
                />
            </div>
            <div class="input-shared-container">
                <label>Repetir contrasena</label>
                <input
                    class="input-shared-component"
                    v-model="repetirContrasena"
                />
            </div>

            <ButtonShared
                class="login-container__button"
                :text="'Actualizar'"
                :type="'large'"
                :bgColor="'red'"
                :loading="loadingButton"
                :disabled="loadingButton"
            />

            <ErrorModalShared
                @Event="closeModal"
                v-if="isShowModalError"
                :title="error.title"
                :description="error.description"
            />
        </div>
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
                contrasena:"******",
                nuevaContrasena: "Opcional",
                repetirContrasena: "Opcional",
                user: UsuarioGet,
                loadingButton: false,
                isShowModalError: false,

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
                    console.log(this.user);  
                }
                catch (error) {
                    console.log(error);        
                }
            },

            closeModal() {
                this.isShowModalError = false;
            },

            actualizarDatos(){}
        }
    }
</script>

<style>

.user-edit-container {
    margin: 0px 40px 160px 40px;
    position: relative;
    width: 100%;
    height: 100%;
}

.user-edit-containerr__header {
    padding-top: 64px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.user-edit-container h1 {

    font-size: 20px;
    font-weight: 700;
    margin: 16px 0 8px 0;
}
.user-edit-container__header p {
    font-size: 14px;
}
.user-edit-container__form-container {
    display: flex;
    justify-content: right;
    align-items: right;
    flex-direction: column;
    margin-top: 8px;
}

.user-edit-container__button {
  margin-top: 14px;
}
.input-shared-container {
  margin-bottom: 24px;
}

</style>