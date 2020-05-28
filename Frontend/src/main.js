import Vue from 'vue'
import App from './App.vue'
import router from './routing/routing';
import { environments } from './app/environments/environments';
import 'ant-design-vue/dist/antd.css';
import Antd from 'ant-design-vue';

Vue.config.productionTip = false
Vue.use(Antd);
if (process.env.NODE_ENV === "production") {
  environments.api = environments.apiProduction
}



new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
