import {Component, Model, Prop, Vue, Watch} from "vue-property-decorator";
import {ITeam, Team} from "../../../../shared/model/team.model";
import {iUniversity, University} from "../../../../shared/model/university.model";

// @ts-ignore
@Component()
export default // @ts-ignore
class TeamForm extends Vue{

    // @ts-ignore
    @Model('change')  team!:iUniversity = new University(0,"");
    public originalImg :String = "";
    public originalNameTeam:String = "";
    public renderForm: boolean = true;
    // @ts-ignore
    @Watch("value")
    // @ts-ignore
    changed(){
        alert("sd");
    }
    // deprecated
    @Watch('team')
    // @ts-ignore
    onTeamChanged(newTeam: ITeam, oldVal: ITeam){
    }

    public url:String= "";
    public onFileChange(e) {
    }
    public reset(){
        this.url = "";
        // @ts-ignore
        this.team.Title = this.team.Id > 0 ? this.originalNameTeam : "";
        try {
            // @ts-ignore
            this.$refs["fileupload"].value = null;
            // @ts-ignore
            this.$refs["imgLoaded"].src = null;
        }catch (e){
            
        }
    }
    public validateForm(e){
    }
    public onCancel(){
        try {
            this.team = new University(0,"");
        }catch (e) {
            
        }
    }
  
 
}