<template>
  <div class="sale-container">
    <div class="sale-container__header">
      <h2>{{ nombre }}</h2>
      <p color-rojo>{{ dni }}</p>
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
  </div>
</template>

<script>
export default {


  name: "SalePage",
  data() {
    return {
      inputValue: 0,
      inputValue1: 1,
      nombre: "Jair Huaman Bellido",
      dni: "78451234",
      products: [
        { name: "Arroz(U)", defaultValue: 3, minValue: 1, maxValue: 5,marks: {1:1, 5:5} },
        { name: "Legumbre(kg)", defaultValue: 1, minValue: 1, maxValue: 2, marks:{1:1,2:2}},
      ],
    };
  },
  methods: {
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
</style>
