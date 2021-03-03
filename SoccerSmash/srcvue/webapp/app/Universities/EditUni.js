import Vue from 'vue';
import EditComponent from "./Components/EditComponent";

const app = new Vue({
    props: ["team"],
    "el":"#EditComponent",
    components:{EditComponent}
})