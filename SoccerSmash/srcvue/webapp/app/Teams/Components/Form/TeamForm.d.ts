import { Vue } from "vue-property-decorator";
import { ITeam } from "../../../../shared/model/team.model";
export default class TeamForm extends Vue {
    team: ITeam;
    originalImg: String;
    originalNameTeam: String;
    renderForm: boolean;
    changed(): void;
    onTeamChanged(newTeam: ITeam, oldVal: ITeam): void;
    url: String;
    onFileChange(e: any): void;
    reset(): void;
    validateForm(e: any): void;
    onCancel(): void;
}
