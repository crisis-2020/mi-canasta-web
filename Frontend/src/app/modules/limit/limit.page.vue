<template>
  <div class="request-sent-container">
    <div class="request-sent__title">
      <h2>Compras de la Semana</h2> 
      <div class="set-date-label">
      <p> 21/06/2020 al 28/06/20 </p>
    </div> </div>

    <div class="container-components">
        <p>Arroz</p>
      <HorizontalBarShared
          :cards="dataHorizontaBar"   
        /> <br><br>
    </div> 

    <div class="container-components">
        <p>Lentejas</p>
      <HorizontalBarShared
          :cards="dataHorizontaBar2"
      /><br><br>
    </div>

    <div class="container-components">
        <p>Aceite</p>
      <HorizontalBarShared
          :cards="dataHorizontaBar3"
      /><br><br>
    </div>

    <div class="container-components">
        <p>Papel Higiénico</p>
      <HorizontalBarShared
          :cards="dataHorizontaBar4"
      /><br><br>
    </div>

  </div>
</template>

<script>
import HorizontalBarShared from "../../shared/charts/horizontal-bar.component.vue";
//import FamiliaService from '../../core/services/familia.service';
//import { CompraGet } from '../../core/model/compra.model';
//import { ProductoGet } from '../../core/model/producto.model';
export default {
  name: "LimitPage",
  components: {
    HorizontalBarShared
  },

    data: function() {
    return {
      nombreFamilia: "",
      productoId: "",
      cantidad:"",
      fechaCompra:"",

      categoriaId: "",
      descripcion:"",
      cantidadUnit: "",

      fechaInicio:"",
      fechaFin:"",
      //compra: CompraGet,

      dataHorizontaBar:[
        {text: "3kg", color: "green", value: 3},
        {text: "2kg", color: "orange", value: 2},
      ],

      dataHorizontaBar2:[
        {text: "1kg", color: "green", value: 1},
        {text: "3kg", color: "orange", value: 3},
      ],
        
        dataHorizontaBar3:[
        {text: "1lt", color: "green", value: 1},
        {text: "1lt", color: "orange", value: 1},
      ],

        dataHorizontaBar4:[
        {text: "2 rollos", color: "green", value: 2},
        {text: "4 rollos", color: "orange", value: 4},
      ]
    }
  },

      /***created(){
          this.$data.idFamilia = this.$route.params.id;
          this.getCompras();            
      },

      methods:{

      async getCompras(){
        try {
           const res = await FamiliaService.getCompras(this.nombreFamilia,
           this.fechaInicio, this.fechaFin);
           this.compra = res.data;
           this.cantidad = this.compra.cantidad;  
           console.log("777");
         } catch (error) {
           console.log(error);        
           }
        },
      }*/
}

</script>

<style>
.set-date-label{
text-align: center;
}

.container-components{
  margin: -42px;
  position: relative;
  align-items: center;
  align-content: center;
  align-self: center;
  border-radius: 6px;
align-items: center;
justify-content: center;
font-weight:bold;
}
</style>