import Router from "vue-router";
import Vue from "vue";
import LayoutPage from "../app/layout/components/layout/LayoutPage.vue";
import LayoutDelears from "../app/layout/components/layout/LayoutDelears.vue";
import LayoutLogin from "../app/layout/components/layout/LayoutLogin.vue";
import LoginPage from "../app/modules/login/login.page.vue";
import HomePage from "../app/modules/home/home.page.vue";
import SolicitudPage from "../app/modules/solicitud/solicitud.page.vue";
import HomeFamilyPage from "../app/modules/home-family/home-family.page.vue";
import DealersPage from "../app/modules/home-dealers/home-dealers.page.vue";
import SharedPageComponent from "../app/modules/shared-componentes/shared-components.page.vue";
import RequestsSentPage from "../app/modules/request-sent/requests-sent.page.vue";
import RequestReceived from "../app/modules/requests-received/requests-received.page.vue";
import SalePage from "../app/modules/sale/sale.page.vue";
import DealersLocation from "../app/modules/home-dealers/dealers-location.page.vue";
import UserPage from "../app/modules/user/user.page.vue";
import LimitPage from "../app/modules/limit/limit.page.vue";
import BuyPage from "../app/modules/buy/buy.page.vue";
import UserEditPage from "../app/modules/user/user-edit.page.vue";
import StockPage from "../app/modules/stock/stock.page.vue";

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
      path: "/start",
      name: "LayoutStart",
      component: LayoutLogin,
      children: [
        {
          path: "home",
          name: "HomePage",
          component: HomePage,
        },
        {
          path: "requests-sent",
          name: "RequestsSentPage",
          component: RequestsSentPage,
        },
      ],
    },
    {
      path: "/family",
      name: "LayoutPage",
      component: LayoutPage,
      children: [
        { path: "family", name: "FamilyPage", component: HomeFamilyPage },
        { path: "sell", name: "SalePage", component: SalePage },
        { path: "user", name: "UserPage", component: UserPage },
        {
          path: "solicitudes",
          name: "SolicitudPage",
          component: SolicitudPage,
        },
        { path: "family/:id", name: "FamilyPage", component: HomeFamilyPage },
        {
          path: "requests-received",
          name: "RequestReceived",
          component: RequestReceived,
        },
        { path: "sell", name: "SalePage", component: SalePage },
        { path: "user", name: "UserPage", component: UserPage },
        { path: "limit", name: "LimitPage", component: LimitPage },
        { path: "buy", name: "BuyPage", component: BuyPage },
        { path: "user/edit", name: "UserEditPage", component: UserEditPage },
        { path: "stock", name: "StockPage", component: StockPage },
        {
          path: "location",
          name: "DealersLocation",
          component: DealersLocation,
        },
      ],
    },
    {
      path: "/delear",
      name: "LayoutDelears",
      component: LayoutDelears,
      children: [
        
        { path: "dealers/:id", name: "DealersPage", component: DealersPage },
        { path: "dealers", name: "DealersPage", component: DealersPage },
      ],
    },
    {
      path: "/componentes",
      name: "SharedPageComponent",
      component: SharedPageComponent,
    },
  ],
});
