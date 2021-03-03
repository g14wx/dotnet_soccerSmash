import { Vue } from "vue-property-decorator";
import { ITeam } from "../../../shared/model/team.model";
import { IPlayer } from "../../../shared/model/Player.model";
export default class EditComponent extends Vue {
    team: ITeam;
    readonly players: IPlayer[];
    readonly teamplayers: IPlayer[];
    theTeam: ITeam;
    showForm: boolean;
    realtitle: String;
    realImg: String;
    value: string;
    teamPlayers: IPlayer[];
    get SyncTeam(): ITeam;
    show: boolean;
    set SyncTeam(newvVal: ITeam);
    deleteTeam(id: number): void;
    url: String;
    onFileChange(e: any): void;
    validateForm(e: any): void;
    onCancel(): void;
    mounted(): void;
}
