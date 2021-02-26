import Vue from 'vue';
import TeamComponent from "./Components/TeamComponent.vue";

const app = new Vue({
    props: ["teamlist","leaguelist"],
    "el":"#teamComponent",
    components:{TeamComponent}
})