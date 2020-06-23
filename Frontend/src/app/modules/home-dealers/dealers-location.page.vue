<template>
  <div class="dealers-location-container">
    <div class="dealers-location-container__title">
      <h2>Filtrar</h2>
      <a-select
        default-value="Arroz"
        style="width: 120px"
        @change="handleChange"
      >
        <a-select-option value="Arroz">
          Arroz
        </a-select-option>
        <a-select-option value="Leche">
          Leche
        </a-select-option>
      </a-select>
    </div>
    <div class="dealers-location-container__body">
      <div class="dealers-location-container__body__filter">
        <div
          v-on:click="changeOption(i)"
          v-for="(filter, i) in filterOptionsMap"
          v-bind:key="i"
        >
          <img
            v-if="i === actualFilterSelected"
            v-bind:src="filter.iconActivate"
            alt=""
          />
          <img
            v-if="i !== actualFilterSelected"
            v-bind:src="filter.iconDesactivate"
            alt=""
          />
        </div>
      </div>
      <div class="mapa">
        <GmapMap
          :center="{ lat: lat, lng: lng }"
          :zoom="14"
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
// import Mapa from "./components/mapa.vue";
// import Marcadores from "./components/marcadores.mapa.vue";
import { configMapa } from "./components/configMapa";
export default {
  name: "DealersLocation",
  //   components: { Mapa, Marcadores },

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

      emergenciaMarkers: [
        {
          position: { lat: -12.127908, lng: -77.020861 },
          title: "Emergencia 1",
        },
        {
          position: { lat: -12.128988, lng: -77.024208 },
          title: "Emergencia 2",
        },
        {
          position: { lat: -12.128988, lng: -77.024208 },
          title: "Emergencia 3",
        },
      ],
      filterOptionsMap: [
        {
          name: "Kiosko",
          iconActivate: require("../../../assets/stand_activate.svg"),
          iconDesactivate: require("../../../assets/stand_desactivate.svg"),
        },
        {
          name: "Tienda",
          iconActivate: require("../../../assets/shop_activate.svg"),
          iconDesactivate: require("../../../assets/shop_desactivate.svg"),
        },
        {
          name: "Hospital",
          iconActivate: require("../../../assets/hospital_activate.svg"),
          iconDesactivate: require("../../../assets/hospital_desactivate.svg"),
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
    };
  },
  methods: {
    handleChange(value) {
      console.log(`selected ${value}`);
    },

    changeOption(i) {
      this.actualFilterSelected = i;

      if (i === 0) this.mostrarKiosos();
      else if (i === 1) this.mostrarTiendas();
      else this.mostrarEmergencias();
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
  },
  mounted() {
    this.$data.markers = this.$data.kioskoMarkers;
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
