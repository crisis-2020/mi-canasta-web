<template>
  <div class="container-horizontal-bard">
    <div class="line-father">
      <div
        class="line"
        :class="[
        {'red-chart': item.color==='red'},
        {'yellow-chart':item.color==='yellow'},
        {'green-chart': item.color==='green'},
        {'orange-chart': item.color==='orange'}
        
        ]"
        v-bind:style="{ width: (item.value / total) * 100 + '%' }"
        v-for="(item, index) in cards"
        v-bind:key="index"
      >
        <p>{{ item.text }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HorizontalBarShared",

  mounted() {
    this.calculateTotal();
  },
  data: function() {
    return {
      total: 0,
    };
  },
  props: ["cards"],
  methods: {
    calculateTotal() {
      const reduce = (acc, item) => {
        return acc + item.value;
      };

      this.$data.total = this.$props.cards.reduce(reduce, 0);
    },
  },
};
</script>

<style>

.red-chart{
background: #F76A8C;
}
.green-chart{
    background: #CCF0E1;

}
.yellow-chart{
    background: rgb(255, 240, 24);

}
.orange-chart{
    background: #F8DC88;

}
.line-father {
  width: 320px;
  border-radius: 5px;
  height: 40px;
  position: relative;
  overflow: hidden;
  display: flex;
  align-items: center;
  align-content: center;
  align-self: center;
}
.line-father .line {
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  color: #ffffff;
  font-weight: 600;
  align-content: center;
  align-self: center;
}
</style>
