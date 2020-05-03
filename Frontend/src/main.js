import Vue from 'vue'
import App from './App.vue'
import router from './routing/routing';
import { environments } from './app/environments/environments';


Vue.config.productionTip = false

if (process.env.NODE_ENV === "production") {
  environments.api = environments.apiProduction
}



new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
