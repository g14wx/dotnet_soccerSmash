import { Vue } from "vue-property-decorator";
import { ITeam } from "../../../../shared/model/team.model";
export default class TeamForm extends Vue {
    readonly Team: ITeam;
    url: String;
    teamName: String;
    onFileChange(e: any): void;
    reset(): void;
}
