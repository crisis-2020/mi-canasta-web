<template>
  <div class="stock-product-container">
        <input
         type="number"
         class="input-number-shared-component"
         v-model="stockUpdate.cantidad">
        <label> {{ producto.descripcion }} </label><br>
        <b>{{ unidad }}</b>
  </div>
</template>

<script>
import ProductoService from "../../core/services/producto.service";
import CategoriaService from "../../core/services/categoria.service";
import { ProductoRequest } from '../../core/model/request/producto.model';


export default {
    name: "StockProductComponent",
    props: [
    'stockUpdate',
    ],
    
    data: function(){
        return {
            producto: ProductoRequest,
            unidad:"",
        }
    },

    created() {
        this.getProducto();
    },

    methods:{

        async getProducto(){
            try {
                const res = await ProductoService.getProducto(this.stockUpdate.productoId);
                this.producto = res.data;
                this.getCategoria();
            }
            catch (error) {
                console.log(error);        
            }
        },

        async getCategoria(){
            try {
                const res = await CategoriaService.getCategoria(this.producto.categoriaId);
                this.unidad = res.data.tipoUnidad;
            }
            catch (error) {
                console.log(error);        
            }
        },
    }
}
</script>

<style>

.input-number-shared-component {
    width: 90px;
    height: 42px;
    margin: auto 4px auto 4px;
    float: right;
    text-align: center;
}

.label-float {
    margin: 9px auto auto auto;
    float: right;
}

.stock-product-container {
    margin: auto auto 26px auto;
}

</style>