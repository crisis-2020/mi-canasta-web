import Router from "vue-router";
import Vue from "vue";
import LayoutPage from "../app/layout/components/layout/LayoutPage.vue";
import LayoutLogin from "../app/layout/components/layout/LayoutLogin.vue";
import LoginPage from "../app/modules/login/login.page.vue"
import HomePage from "../app/modules/home/home.page.vue";
import HomeFamilyPage from "../app/modules/home-family/home-family.page.vue";
import DealersPage from "../app/modules/home-dealers/home-dealers.page.vue";
import SharedPageComponent from "../app/modules/shared-componentes/shared-components.page.vue"
import RequestsSentPage from "../app/modules/request-sent/requests-sent.page.vue";
Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      redirect: "/login",
    },
    {
      path: "/login",
      name: "LayoutLogin",
      component: LayoutLogin,
      children: [
        {
          path: "/",
          name: "LoginPage",
          component: LoginPage,
        },
      ],
    },
    {
      path: "/home",
      name: "LayoutPage",
      component: LayoutPage,
      children: [
        { path: "/home", name: "HomePage", component: HomePage },
        { path: "family", name: "FamilyPage", component: HomeFamilyPage },
        { path: "dealers", name: "DealersPage", component: DealersPage },
        { path: "requests-sent", name: "RequestsSentPage",component: RequestsSentPage }
      ],
    },
    {
      path: "/componentes",
      name: "SharedPageComponent",
      component: SharedPageComponent,
    },
  ],
});
