import { Vue } from "vue-property-decorator";
import { ITeam } from "../../../shared/model/team.model";
import { ILeague } from "../../../shared/model/League.model";
export default class TeamComponent extends Vue {
    teamlist: ITeam[];
    readonly leaguelist: ILeague[];
    SelectedTeam: ITeam;
    get SyncTeamList(): ITeam[];
    show: boolean;
    set SyncTeamList(newvVal: ITeam[]);
    deleteTeam(id: number): void;
    editTeam(id: number): void;
    newTeam(): void;
    mounted(): void;
}
