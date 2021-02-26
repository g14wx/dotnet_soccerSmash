import Vue from 'vue';
import EditComponent from "./Components/EditComponent";

const app = new Vue({
    props: ["team","players"],
    "el":"#EditComponent",
    components:{EditComponent}
})