:<template>
  <div class="sale-container">
    <div class="sale-container__header">
      <h2> {{ user.nombre +" "+ user.apellidoPaterno }} </h2>
      <p color-rojo> {{ user.dni }} </p>
      
    </div>
    <div
      class="sale-container__slider"
      v-for="(item, i) in products"
      v-bind:key="i"
    >
      <div class="sale-container__slider-header">
        <p>{{ item.name }}</p>
        <a-input-number
          v-model="item.defaultValue"
          :min="item.minValue"
          :max="item.maxValue"
        />
      </div>
      <div class="sale-container__slider-indicators">
        <a-slider
          v-model="item.defaultValue"
          :min="item.minValue"
          :max="item.maxValue"
          :marks="generateLimits(item)"
        />
      </div>
    </div>
 
      <ButtonShared
        class="sell-container__button"
        :text="'Confirmar pedido'"
        :disable="minValue = 0 "
        :type="'small'"
        :bgColor="'red'"
        @Event="confirmarPedido" >
    </ButtonShared>
</div>

</template>


<script>
import ButtonShared from "../../shared/button/button.component.vue";
import UsuarioService from "../../core/services/usuario.service";
import { UsuarioGet } from '../../core/model/usuario.model';


export default {
  name: "BuyPage",
  components: { ButtonShared },
  data: function() {
    return {
      inputValue: 1,
      inputValue1: 1,
      user: UsuarioGet,
      dni: "",
      products: [
        { name: "Arroz(kg)", defaultValue: 3, minValue: 1, maxValue: 5,marks: {1:1, 5:5} },
        { name: "Lenteja(kg)", defaultValue: 2, minValue: 1, maxValue: 4, marks:{1:1,4:4}},
      ],
    };
  },

  created(){
      this.dni = localStorage.getItem("dni");
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

    async confirmarPedido(){
      this.$data.loadingButton = true;
      try{
        this.$router.push(`/home/limit`);
        /**const res = await CompraService.getItem({
        dni: localStorage.getItem("dni"), 
        idFamilia: localStorage.getItem("idFamilia"),**/
      } catch (error) {
        console.log(error);
      this.$data.loadingButton = false;
      }
    },
  
    
    generateLimits(i){
      let a   = {};
      a[1] = 1;
      a[i.maxValue] =  i.maxValue
      return a;
    }
    
  }
};
</script>

<style>
.sale-container {
  height: calc(100vh - 128px);
  width: 100%;
  padding: 60px 32px;
  overflow-y: hidden;
}
.sale-container__header h2 {
  font-size: 20px;
  text-align: center;
  font-weight: 600;
  color: #000;
}

.sale-container__header p {
  font-size: 18px;
  text-align: center;
}

.sale-container__slider {
  margin: 0 0 48px 0;
}
.sale-container__slider-header {
  display: flex;
  align-items: center;
}
.sale-container__slider-header p {
  margin: 0 16px 0 0;
  font-size: 16px;
  font-weight: 600;
  color: #000;
}

.sell-container__button {
  margin-top: 24px;
}
.sell-container__button {
  margin: 0 32px;
}

</style>
