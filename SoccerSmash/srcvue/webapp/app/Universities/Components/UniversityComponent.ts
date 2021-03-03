// @ts-ignore
import {Component, Vue, Prop, PropSync,} from "vue-property-decorator";
import {ITeam, Team} from "../../../shared/model/team.model";
import TeamForm from "./Form/TeamForm.vue";
// @ts-ignore
import ModalComponent from "../../../shared/Components/ModalComponent";
import {ILeague} from "../../../shared/model/League.model";
import Multiselect from "vue-multiselect";
import {iUniversity} from "../../../shared/model/university.model";
@Component({
    components:{
        TeamForm,
        ModalComponent,
        Multiselect
    }
})
export default // @ts-ignore
class UniversityComponent extends Vue {
    // @ts-ignore
    @Prop() public universities!: iUniversity[];
    
    // @ts-ignore
    public get SyncTeamList() {
        return this.universities;
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
                url: `/university/${id}`
            }    
        ).then((res)=> {
            this.show = false;
            this.universities.splice(this.universities.findIndex(t=>t.Id==id),1);
            this.show = true;
        }).catch(error=>{
        });
    }
    
    public editTeam(id: number){
        window.location.href=`/universities/edit/${id}`;
    }
    
    public newTeam(){
    }
    mounted(){
    }
}