// @ts-ignore
import { Component, Vue, Prop } from "vue-property-decorator";
import {ITeam, Team} from "../../../shared/model/team.model";
@Component
export default // @ts-ignore
class TeamComponent extends Vue {

    // @ts-ignore
    @Prop() public readonly teamlist!: ITeam[];
    
    mounted(){
        console.log(this.teamlist.length);
    }
}