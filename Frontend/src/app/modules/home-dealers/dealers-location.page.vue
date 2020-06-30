<template>
  <div class="dealers-location-container">
    <div class="dealers-location-container__title">
      <h2>Filtrar</h2>
      <div>
        <a-select
          style="width: 120px"
          @change="handleChange"
        >
          <a-select-option v-for="(producto, i) in productos" :key="i">
            {{ producto.nombre }}
          </a-select-option>
        </a-select>
        <a-input-number
          id="inputNumber"
          v-model="maxValue"
          :min="1"
          :max="maxValue"
        />
      </div>
    </div>
    <div class="dealers-location-container__body">
      <div class="dealers-location-container__body__filter">
        <div
          v-on:click="changeOption(i)"
          v-for="(filter, i) in filterOptionsMap"
          v-bind:key="i"
        >
          <img
            v-if="filter.flag === true"
            v-bind:src="filter.iconActivate"
            alt=""
          />
          <img
            v-if="filter.flag !== true"
            v-bind:src="filter.iconDesactivate"
            alt=""
          />
        </div>
      </div>
      <div class="mapa">
        <GmapMap
          :center="{ lat: lat, lng: lng }"
          :zoom="13"
          :options="{
            zoomControl: true,
            mapTypeControl: false,
            scaleControl: false,
            streetViewControl: false,
            rotateControl: false,
            fullscreenControl: true,
            disableDefaultUI: false,
          }"
          style="width: 100%; height: 400px"
        >
          <GmapMarker
            :key="index"
            v-for="(m, index) in markers"
            :position="m.position"
            :clickable="true"
            :draggable="true"
            @click="center = m.position"
          />
        </GmapMap>
      </div>
    </div>
  </div>
</template>

<script>
import TiendaService from "../../core/services/tienda.service";
import ProductoService from "../../core/services/producto.service";
import { configMapa } from "./components/configMapa";
export default {
  name: "DealersLocation",

  data() {
    return {
      actualFilterSelected: 0,
      lat: -12.063857,
      lng: -77.035029,
      kioskoMarkers: [
        {
          position: { lat: -12.063437, lng: -77.039903 },
          title: "Punto 1 kiosko",
        },
        {
          position: { lat: -12.06457, lng: -77.040104 },
          title: "Punto 2 Kiosko",
        },
      ],

      tiendaMarkers: [
        { position: { lat: -12.095683, lng: -76.997026 }, title: "Tienda 1" },
        { position: { lat: -12.099292, lng: -76.999054 }, title: "Tienda 2" },
        { position: { lat: -12.099093, lng: -76.999226 }, title: "Tienda 3" },
      ],

      productos: [],

      productoSeleccionado: null,

      tiendas: [],

      superMercados: [],

      filterOptionsMap: [
        {
          name: "Kiosko",
          iconActivate: require("../../../assets/stand_activate.svg"),
          iconDesactivate: require("../../../assets/stand_desactivate.svg"),
          flag: true,
          arr: this.kioskoMarkers,
        },
        {
          name: "Tienda",
          iconActivate: require("../../../assets/shop_activate.svg"),
          iconDesactivate: require("../../../assets/shop_desactivate.svg"),
          flag: true,
          arr: this.tiendaMarkers,
        },
      ],

      markers: [
        {
          id: "0",
          position: { lat: -13.1583635, lng: -72.603623 },
          title: "Machu Pichu - Cusco",
        },
        {
          id: "1",
          position: { lat: -12.025827, lng: -77.2679817 },
          title: "Lima - Perú",
        },
      ],
      maxValue: 3,
    };
  },
  methods: {
    handleChange(value) {
      
      this.maxValue = (this.productos[value].stock);
    },

    changeOption(i) {
      this.actualFilterSelected = i;

      this.filterOptionsMap[i].flag = !this.filterOptionsMap[i].flag;

      let aux = this.filterOptionsMap
        .filter((e) => e.flag === true)
        .map((e) => e.arr);

      this.markers = [...aux][0] ? [...aux][0].concat([...aux][1] || []) : [];
    },

    mostrarKiosos() {
      this.lat = -12.063857;
      this.lng = -77.035029;
      this.markers = this.kioskoMarkers;
    },
    mostrarTiendas() {
      this.lat = -12.096973;
      this.lng = -76.99517;
      this.markers = this.tiendaMarkers;
    },
    mostrarEmergencias() {
      this.lat = -12.127908;
      this.lng = -77.020861;
      this.markers = this.emergenciaMarkers;
    },

    async listarTiendas() {
      try {
        const _tiendas = await TiendaService.listarTiendas();

        this.$data.tiendas = [_tiendas.data[0], _tiendas.data[1]];
      } catch (error) {
        console.log(error);
      }
    },

    async listarSuperMercados() {
      try {
        const _superMarkets = await TiendaService.listarTiendas();
        this.$data.superMercados = [_superMarkets.data[0]];
      } catch (error) {
        console.log(error);
      }
    },

    async listarTodasTiendas() {
      try {
        const tiendas = await TiendaService.listarTiendas();

        tiendas.data.forEach(async (tienda) => {
          try {
            const stocks = await TiendaService.listarStock(tienda.tiendaId);
            stocks.data.forEach(async (stock) => {
              try {
                const res = await ProductoService.getProducto(stock.productoId);
                console.log(res.data);
                this.productos.push({
                  nombre: res.data.descripcion,
                  stock: stock.cantidad,
                });
                this.maxValue = this.productos[0].stock;
              } catch (error) {
                console.log(error);
              }
            });
          } catch (error) {
            console.log(error);
          }
        });
      } catch (error) {
        console.log("error", error);
      }
    },
  },
  mounted() {
    this.filterOptionsMap[0].arr = this.$data.kioskoMarkers;
    this.filterOptionsMap[1].arr = this.$data.tiendaMarkers;

    this.$data.markers = [
      ...this.$data.kioskoMarkers,
      ...this.$data.tiendaMarkers,
    ];
    this.listarTiendas();
    this.listarSuperMercados();

    this.listarTodasTiendas();
  },
  computed: {
    configMapa() {
      return {
        ...configMapa,
        center: this.mapCenter,
      };
    },

    mapCenter() {
      return this.markers[0].position;
    },
  },
};
</script>

<style>
.mapa {
  min-height: 425px !important;
  width: 100%;
}

.dealers-location-container {
  padding: 0 32px;
  height: calc(640px - 128px);
  overflow: auto;
}

.dealers-location-container__title {
  margin: 24px 0;
  display: flex;
  flex-direction: column;
}



.dealers-location-container__title h2 {
  margin-right: 16px;
}

.dealers-location-container__body__filter {
  display: flex;
  margin: 24px 0;
  flex-direction: row;
  justify-content: space-between;
}
</style>
