import {Component, Model, Prop, Vue, Watch} from "vue-property-decorator";
import {ITeam, Team} from "../../../../shared/model/team.model";

// @ts-ignore
@Component()
export default // @ts-ignore
class TeamForm extends Vue{

    // @ts-ignore
    @Model('change')  team!:ITeam;
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
        const file = e.target.files[0];
        this.url = URL.createObjectURL(file);
        this.team.Img = "changed";
    }
    public reset(){
        this.url = "";
        // @ts-ignore
        this.team.Title = this.team.Id > 0 ? this.originalNameTeam : "";
        // @ts-ignore
        this.team.Img = this.team.Id > 0 ? this.originalImg : "";
        try {
            // @ts-ignore
            this.$refs["fileupload"].value = null;
            // @ts-ignore
            this.$refs["imgLoaded"].src = null;
        }catch (e){
            
        }
    }
    public validateForm(e){
        if(this.url.length == 0){
            e.preventDefault();
        }
    }
    public onCancel(){
        try {
            this.team = new Team(0,"","");
        }catch (e) {
            
        }
    }
  
 
}