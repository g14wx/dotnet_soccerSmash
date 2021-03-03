import Vue from 'vue';
import UniversityComponent from "./Components/UniversityComponent.vue";

const app = new Vue({
    props: ["universities"],
    "el":"#teamComponent",
    components:{UniversityComponent}
})
