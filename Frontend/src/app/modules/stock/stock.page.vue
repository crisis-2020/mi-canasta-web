<template>
  <div class="stock-container">
      <div class="field-container margin">
            <h1 class="stock-container__header h1">
                Stock
            </h1>
            <div class="stock-container__form-container">
                <div class="stock-container__list-stocks">
                    <stock-product-component
                    :stockUpdate="stockUpdate"
                    v-for="(stockUpdate, i) in stocksUpdate"
                    v-bind:key="i"
                    />
                </div>
            </div>
            <div>
                <ButtonShared
                    class="stock-container__button"
                    :text="'Actualizar'"
                    :type="'large'"
                    :bgColor="'red'"
                    :loading="loadingButton"
                    :disable="flagAdmin"
                    @Event="actualizarStock"
                />
            </div>
      </div>
    <ErrorModalShared
      v-if="flagModal"
      :title="'Confirmación'"
      :description="'Los datos fueron actualizados'"
      @Event="cerrarModal"
    ></ErrorModalShared>
  </div>
</template>

<script>
import StockProductComponent from "../../modules/stock/stock.product.vue";
import StockService from "../../core/services/stock.service";
import ButtonShared from "../../shared/button/button.component.vue";
import TiendaService from "../../core/services/tienda.service";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";

export default {
    name: "StockPage",
    components: { StockProductComponent, ButtonShared, ErrorModalShared },
    data: function() {
            return {
                stocks: [],
                loadingButton: false,
                stocksUpdate: [],
                flagModal:false,
                flagAdmin:true,
            }
    },

    created() {
        this.getStocksFirst();
        this.isAdmin();
    },

    methods: {

        isAdmin(){
            for(let i=0; i<JSON.parse(localStorage.getItem('data')).rolUsuario.length; i++){
                if(JSON.parse(localStorage.getItem('data')).rolUsuario[i].rolPerfilId == 3){
                    this.flagAdmin = false; 
                }
            }
        },

        async getStocksFirst(){
            try {
                const res = await StockService.getStocks(JSON.parse(localStorage.getItem('data')).tienda.tiendaId);
                this.stocksUpdate = res.data;
            }
            catch (error) {
                console.log(error);        
            }
        },

        async getStocksSecond(){
            try {
                const res = await StockService.getStocks(JSON.parse(localStorage.getItem('data')).tienda.tiendaId);
                this.stocks = res.data;
            }
            catch (error) {
                console.log(error);        
            }
        },

        async putStock(i){
            try {
                if(this.stocks[i].cantidad != this.stocksUpdate[i].cantidad){
                    await TiendaService.putStock(this.stocks[i].tiendaId,
                    this.stocks[i].productoId, { cantidad: parseInt(this.stocksUpdate[i].cantidad) });
                }
            }

            catch (error) {
                console.log(error);        
            }
        },

        async actualizarStock(){
            await this.getStocksSecond();
            this.loadingButton = true;
            for(let i = 0; i < this.stocksUpdate.length; i++){
                this.putStock(i);
            }
            this.loadingButton = false;
            this.flagModal = true;
        },

        cerrarModal(){
            this.flagModal = false;
        }
    },
}
</script>

<style>
.field-container {
    margin: 0px 30px 0px 30px;
}
.stock-container h1 {
    justify-content: right;
    align-items: right;
    font-size: 20px;
    font-weight: 700;
    margin: 16px 0 26px 0;
}
.stock-container__button {
    justify-content: center;
    align-items: center;
    margin: 36px auto auto auto
}
</style>