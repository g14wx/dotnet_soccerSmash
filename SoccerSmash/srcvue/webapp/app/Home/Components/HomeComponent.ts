// @ts-ignore
import { Component, Vue } from "vue-property-decorator";
@Component
export default // @ts-ignore
class HomeComponent extends Vue {
    mounted() {
        alert("mounted!");
    }
}