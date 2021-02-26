import {Component,Prop,Vue} from "vue-property-decorator";
import {ITeam} from "../../../../shared/model/team.model";

@Component
export default // @ts-ignore
class TeamForm extends Vue{
    // @ts-ignore
    @Prop public readonly Team : ITeam;
    public url:String= "";
    public teamName : String = "";
    public onFileChange(e) {
        const file = e.target.files[0];
        this.url = URL.createObjectURL(file);
    }
    public reset(){
        this.teamName = "";
        // @ts-ignore
        this.$refs["fileupload"].value = null;
        // @ts-ignore
        this.$refs["imgLoaded"].src = null;
    }
}