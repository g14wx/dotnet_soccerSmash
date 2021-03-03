// @ts-ignore
import {Component, Vue, Prop, PropSync,} from "vue-property-decorator";
import {ITeam, Team} from "../../../shared/model/team.model";
import TeamForm from "./Form/TeamForm.vue";
// @ts-ignore
import {ILeague} from "../../../shared/model/League.model";
import Multiselect from "vue-multiselect";
import {IPlayer, Player} from "../../../shared/model/Player.model";

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
    // @ts-ignore
    @Prop() public readonly teamplayers!:IPlayer[];

    public theTeam : ITeam = new Team(0,"","");
    public showForm: boolean = false;
    public realtitle : String;
    public realImg: String;
    public value:string =  '';
    // @ts-ignore
    public teamPlayers:IPlayer[] = [];
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

    public url:String= "";
    public onFileChange(e) {
        const file = e.target.files[0];
        this.url = URL.createObjectURL(file);
    }

    public validateForm(e){
        if(this.theTeam.Title == this.realtitle){
            if(this.url.length == 0){

                e.preventDefault();
            }
        }
    }

    public onCancel(){
        this.showForm = false;
        this.url= "";
        // @ts-ignore
        this.theTeam.Img = this.realImg;
        // @ts-ignore
        this.theTeam.Title = this.realtitle;

        try {
            // @ts-ignore
            this.$refs["fileupload"].value = null;
        }catch (e){

        }
    }

    mounted(){
        this.teamPlayers = this.teamplayers;
        this.theTeam = this.team;
        this.realImg = this.team.Img;
        this.realtitle = this.team.Title;
    }
}