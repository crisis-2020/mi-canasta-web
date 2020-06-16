:<template>
    <div class="user-container">
        <div class="field-container margin">
            <div>
                <img class = "image-left" src="../../../assets/ic_settings.svg" alt="">
                <img class = "image-right" src="../../../assets/ic_change.svg" alt="">
            </div>
            <br>
            <img id='barcode' 
            :src="src"
            alt="" 
            title="User" 
            class="center"
            width="100" 
            height="100" />
            <br>
            <h1 class="user-h1"> {{ user.nombre +" "+ user.apellidoPaterno }} </h1>
            <label class="user-label-dni"> {{ user.dni }} </label><br><br>
            <label class="user-label-title"> Correo </label>
            <label class="user-label"> {{ user.correo }} </label><br>
            <label class="user-label-title"> {{ descriptionRoles }} </label>
            <li
            v-for="rol in user.rolUsuarios" :key="rol.rolPerfilId"
            >
                <label  class="user-label" v-if="
                (rol.rolPerfilId == 1 && userType == 0) ||
                (rol.rolPerfilId == 3 && userType == 1)">
                    <img  src="../../../assets/ic_crown.svg" alt="">
                    Administrador
                </label>
                <label  class="user-label" v-if="
                (rol.rolPerfilId == 2 && userType == 0) ||
                (rol.rolPerfilId == 4 && userType == 1)">
                    <img  src="../../../assets/ic_shop-cart.svg" alt="">
                    {{ responsable }}
                </label>
            </li>
        </div>
    </div>
</template>

<script>
import UsuarioService from "../../core/services/usuario.service";
import { UsuarioGet } from '../../core/model/usuario.model';

    export default {

        data: function() {
            return {
                name: "UserPage",
                dni: "",
                src: "",
                user: UsuarioGet,
                descriptionRoles: "Roles en Grupo Familiar",
                userType: 0, //familia
                responsable: "Responsable de compra",
            };
        },

        created(){
            this.dni = localStorage.getItem("dni");
            this.src = "https://api.qrserver.com/v1/create-qr-code/?data="+this.dni+"&amp;size=100x100";
            this.getUsuario();
        },

        methods: {
            async getUsuario(){
                try {
                    const res = await UsuarioService.getUsuario(localStorage.getItem("dni"));
                    this.user = res.data;  
                }
                catch (error) {
                    console.log(error);        
                }
            },

            changeProfile(){
                if(this.userType == 0){
                    this.responsable = "Responsable de venta";
                    this.descriptionRoles = "Roles en Tienda";
                    this.userType = 1;
                }
                else {
                    this.responsable = "Responsable de compra";
                    this.descriptionRoles = "Roles en Grupo Familiar";
                    this.userType = 0;
                }
            },
        }
    }
</script>

<style>

.field-container {
  margin: 28px 40px 160px 40px;
  display: flex;
  flex-direction: column;
  
}
.center {
  display: block;
  margin-left: auto;
  margin-right: auto;
}

.user-h1 {
    text-align: center;
    font-size: 23px;
    font-weight: bold;
    color: #000;
}

.br {
    text-align: center;
}

.user-label-dni {
    text-align: center;
    color: #F76A8C;
    font-size: 20px;
}

.user-label-title {
    text-align: left;
    color: #F76A8C;
    font-size: 18px;
    font-weight: bold;
}

.user-label {
    text-align: left;
    color: #000;
    font-size: 18px;
}

.image-left {
    display: block;
    float: left;
    width: 30px;
    height: 30px;
}

.image-right {
    display: block;
    float: right;
    width: 30px;
    height: 30px;
}

</style>