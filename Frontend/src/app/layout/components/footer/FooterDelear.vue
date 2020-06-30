<template>
  <div class="footer-container">
    <div class="footer-container__list">
      <li>
        <img
          class="footer-container__list__noselected"
          :class="{'active': 1 == activedIndex}"
          v-on:click="onSelecteFooterIcon(1)"
          src="@/assets/ic_location.svg"
          alt
        />
      </li>
      <li>
        <img
          class="footer-container__list__noselected"
          :class="{'active': 2 == activedIndex}"
          v-on:click="onSelecteFooterIcon2(2)"
          src="@/assets/ic_team.svg"
          alt
        />
      </li>
      <li>
        <img
          class="footer-container__list__noselected"
          :class="{'active': 3 == activedIndex}"
          v-on:click="onSelecteFooterIcon3(3)"
          src="@/assets/ic_order.svg"
          alt
        />
      </li>
      <li>
        <img
          class="footer-container__list__noselected"
          :class="{'active': 4 == activedIndex}"
          v-on:click="onSelecteFooterIcon4(4)"
          src="@/assets/ic_profile.svg"
          alt
        />
      </li>
    </div>
  </div>
</template>

<script>
import AuthService from '../../../core/services/auth.service';
export default {
  name: "FooterDelearComponent",
  created() {
    this.$data.activedIndex = 2;
  },

  data: function() {
    return {
      activedIndex: 2
    };
  },

  methods: {
    onSelecteFooterIcon: function(index) {
      this.$data.activedIndex = index;
      this.$router.push(`/dealer/location`);
    },

    onSelecteFooterIcon2: function(index) {
      this.$data.activedIndex = index;
      let data = AuthService.getUsuarioAutenticacion();
      this.$router.push(`/dealer/dealers/` + data.usuario.tienda.tiendaId);
    },

    onSelecteFooterIcon3: function(index) {
      this.$data.activedIndex = index;
      this.$router.push(`/dealer/stock`);
    },

    onSelecteFooterIcon4: function(index) {
      this.$data.activedIndex = index;
      this.$router.push(`/dealer/user`);
    }
  }
};
</script>

<style>
.footer-container {
  position: absolute;
  height: 64px;
  bottom: 0;
  width: 100%;
}
.footer-container__list {
  width: 100%;
  display: flex;
  justify-content: space-around;
  align-items: center;
  height: 100%;
}
.footer-container__list__noselected {
  filter: grayscale(100%);
  transition: all 0.2s ease-in-out;
  opacity: 0.3;
}
.footer-container__list li {
  cursor: pointer;
}
.active {
  filter: grayscale(0%) !important ;
  opacity: 1;
  /* opacity: 0.3; */
}
</style>
