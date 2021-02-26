// @ts-ignore
import {Component, Vue, Prop, PropSync,} from "vue-property-decorator";
import {ITeam, Team} from "../../../shared/model/team.model";
import TeamForm from "./Form/TeamForm.vue";
// @ts-ignore
import ModalComponent from "../../../shared/Components/ModalComponent";
import {ILeague} from "../../../shared/model/League.model";
import Multiselect from "vue-multiselect";
@Component({
    components:{
        TeamForm,
        ModalComponent,
        Multiselect
    }
})
export default // @ts-ignore
class TeamComponent extends Vue {
    // @ts-ignore
    @Prop() public teamlist!: ITeam[];
    // @ts-ignore
    @Prop() public readonly leaguelist!: ILeague[];
    
    public SelectedTeam : ITeam = new Team(0,"","");
    // @ts-ignore
    public get SyncTeamList() {
        return this.teamlist;
    }
    public show :boolean = true;
    public set SyncTeamList(newvVal){
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
            this.show = false;
            this.teamlist.splice(this.teamlist.findIndex(t=>t.Id==id),1);
            this.show = true;
        }).catch(error=>{
        });
    }
    
    public editTeam(id: number){
        this.SelectedTeam = null;
        var team : ITeam = this.teamlist.find(t => t.Id = id);
        this.SelectedTeam = team;
        console.log("from team component: ",this.SelectedTeam.Id);
    }
    
    public newTeam(){
        this.SelectedTeam = new Team(0,"","");
    }
    mounted(){
    }
}