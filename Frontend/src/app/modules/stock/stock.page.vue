<template>
  <div class="stock-container">
      <div class="field-container margin">
            <h1 class="stock-container__header h1">
                Stock
            </h1>
            <div class="stock-container__form-container">
                <div class="stock-container__list-stocks">
                    <stock-product-component
                    :stock="stock"
                    v-for="(stock, i) in stocks"
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
                    @Event="actualizarStock"
                />
            </div>
      </div>
  </div>
</template>

<script>
import StockProductComponent from "../../modules/stock/stock.product.vue";
import StockService from "../../core/services/stock.service";
import ButtonShared from "../../shared/button/button.component.vue";

export default {
    name: "StockPage",
    components: { StockProductComponent, ButtonShared },
    data: function() {
            return {
                stocks: [],
                data: {},
                loadingButton: false,
            }
    },

    created() {
        this.getStocks();
    },

    methods: {
        async getStocks(){
            try {
                const res = await StockService.getStocks(JSON.parse(localStorage.getItem('data')).tienda.tiendaId);
                this.stocks = res.data;
            }
            catch (error) {
                console.log(error);        
            }
        },

        actualizarStock(){

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