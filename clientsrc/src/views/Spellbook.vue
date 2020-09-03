<template>
  <div class="spellbook row">
    <div v-for="spell in spellbook" class="col-3" :key="spell.id">
      <h1>{{spell.name}}</h1>

      <img class="img-fluid" :src="spell.imgUrl" alt />
    </div>
  </div>
</template>


<script>
export default {
  name: "spellbook",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getFavoriteCars");
  },
  computed: {
    cars() {
      // NOTE this could also be spellbook we can reuse this property.
      return this.$store.state.cars;
    },
  },
  methods: {},
  components: {},
};
</script>


<style lang="scss" scoped>
</style>