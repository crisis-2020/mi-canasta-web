import Router from "vue-router";
import Vue from 'vue';
import LayoutPage from "../app/layout/components/layout/LayoutPage.vue";
import LayoutLogin from "../app/layout/components/layout/LayoutLogin.vue";
import LoginPage from "../app/modules/login/login.page.vue"
import HomePage from "../app/modules/home/home.page.vue";
import SharedPageComponent from "../app/modules/shared-componentes/shared-components.page.vue"
Vue.use(Router)

export default new Router({
    mode: "history",
    routes: [
        {
            path: '/',
            name: "LayoutPage",
            component: LayoutPage,
            children: [

                { path: '/home', name: 'HomePage', component: HomePage }
            ]

        },
        {
            path: '/login',
            name: 'LayoutLogin',
            component: LayoutLogin,
            children: [
                {
                    path: '/',
                    name: 'LoginPage',
                    component: LoginPage
                }
            ]
        },
        {

            path: '/componentes',
            name: "SharedPageComponent",
            component: SharedPageComponent

        }

    ]
})
