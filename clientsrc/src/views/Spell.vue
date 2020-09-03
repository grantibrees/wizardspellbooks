<template>
  <div class="spell">
    <div v-if="spell.name">
      <h1>{{spell.name}}</h1>
      <button class="btn btn-warning" @click="addToSpellbook()">Spellbook</button>
    </div>
    <h1 v-else>Loading...</h1>
  </div>
</template>

<script>
export default {
  name: "spell",
  mounted() {
    this.$store.dispatch("getActiveSpell", this.$route.params.spellId);
  },
  computed: {
    spell() {
      return this.$store.state.activeSpell;
    },
  },
  methods: {
    addToSpellbook() {
      let spellbook = {
        spellId: this.spell.id,
      };
      this.$store.dispatch("addToSpellbook", spellbook);
    },
  },
};
</script>
