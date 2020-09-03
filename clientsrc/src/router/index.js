import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from '../views/Home.vue'
// @ts-ignore
import Spells from '../views/Spells.vue'
// @ts-ignore
import Spellbook from '../views/Spellbook.vue'
// @ts-ignore
import Spell from '../views/Spell.vue'
// @ts-ignore
import { authGuard } from "@bcwdev/auth0-vue"

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/spells',
      name: 'spells',
      // @ts-ignore
      component: Spells,
      beforeEnter: authGuard
    },
    {
      path: '/spellbook',
      name: 'spellbook',
      component: Spellbook,
      beforeEnter: authGuard
    },
    // {
    //   path: '/spells/:spellId',
    //   name: 'spell',
    //   component: Spell
    // },
    {
      path: "*",
      redirect: '/spellbook'
    }
  ]
})