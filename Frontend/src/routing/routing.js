import Router from "vue-router";
import Vue from 'vue';
import LayoutPage from "../app/layout/components/layout/LayoutPage.vue";
import LoginPage from "../app/modules/login/login.page.vue"
Vue.use(Router)

export default new Router({
    mode: "history",
    routes: [
        {
            path: '/',
            name: "LayoutPage",
            component: LayoutPage,
            children: [
                {
                    path: '/login',
                    name: "LoginPage",
                    component: LoginPage
                }
            ]
        }
    ]
})
