import { Vue } from "vue-property-decorator";
import { iUniversity } from "../../../shared/model/university.model";
export default class UniversityComponent extends Vue {
    universities: iUniversity[];
    get SyncTeamList(): iUniversity[];
    show: boolean;
    set SyncTeamList(newvVal: iUniversity[]);
    deleteTeam(id: number): void;
    editTeam(id: number): void;
    newTeam(): void;
    mounted(): void;
}
