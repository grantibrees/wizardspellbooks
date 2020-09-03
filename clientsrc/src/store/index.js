import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from '../router/index'

Vue.use(Vuex)

//Allows axios to work locally or live
let base = window.location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: base + "api/",
  timeout: 3000,
})

export default new Vuex.Store({
  state: {
    user: {},
    spells: [],
    activeSpell: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setSpells(state, spells) {
      state.spells = spells
    },
    setActiveSpell(state, spell) {
      state.activeSpell = spell
    }
  },
  actions: {
    //#region -- AUTH STUFF --
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#endregion


    //#region -- BOARDS --
    getSpells({ commit }) {
      api.get('spells')
        .then(res => {
          commit('setSpells', res.data)
        })
    },
    async addSpell({ dispatch }, spellData) {
      try {
        let res = await api.post('spells', spellData)
        dispatch("getSpells")
      } catch (error) {
        console.error(error)
      }
    },
    async getActiveSpell({ commit }, spellId) {
      try {
        let res = await api.get("spells/" + spellId)
        commit("setActiveSpell", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async addToSpellbook({ commit, dispatch }, Spellbook) {
      try {
        let res = await api.post("Spellbook", Spellbook)
        console.log(res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getSpellbookSpells({ commit }) {
      try {
        let res = await api.get("Spellbook")
        commit("setSpells", res.data)
      } catch (error) {
        console.error(error);
      }
    }
    //#endregion


    //#region -- LISTS --



    //#endregion
  }
})
