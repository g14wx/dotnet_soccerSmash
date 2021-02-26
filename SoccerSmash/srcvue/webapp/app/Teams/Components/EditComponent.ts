// @ts-ignore
import {Component, Vue, Prop, PropSync,} from "vue-property-decorator";
import {ITeam, Team} from "../../../shared/model/team.model";
import TeamForm from "./Form/TeamForm.vue";
// @ts-ignore
import {ILeague} from "../../../shared/model/League.model";
import Multiselect from "vue-multiselect";
import {IPlayer} from "../../../shared/model/Player.model";

import ProfileCardComponent from "../../../shared/Components/ProfileCardComponent.vue";
@Component({
    components:{
        ProfileCardComponent,
        Multiselect
    }
})
export default // @ts-ignore
class EditComponent extends Vue {
    // @ts-ignore
    @Prop() public team!: ITeam;
    // @ts-ignore
    @Prop() public readonly players!: IPlayer[];

    public SelectedTeam : ITeam = new Team(0,"","");
    // @ts-ignore
    public get SyncTeam() {
        return this.team;
    }
    public show :boolean = true;
    public set SyncTeam(newvVal){
        // @ts-ignore
        return newvVal;
    }

    public deleteTeam(id:number){
        // @ts-ignore
        $axios(
            {
                method: 'delete',
                url: `/teams/${id}`
            }
        ).then((res)=> {
            window.location.href="/teams";
        }).catch(error=>{
        });
    }

    mounted(){
        alert(this.players.length);
    }
}