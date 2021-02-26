import { Vue } from "vue-property-decorator";
import { ITeam } from "../model/team.model";
import { IPlayer } from "../model/Player.model";
export default class profileCardComponent extends Vue {
    team: ITeam;
    innerList: IPlayer[];
    ftitle: String;
    stitle: String;
    ttitle: String;
    players: IPlayer[];
    mounted(): void;
}
