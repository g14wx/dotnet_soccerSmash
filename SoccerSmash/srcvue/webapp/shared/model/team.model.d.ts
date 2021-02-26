export interface ITeam {
    Id?: number;
    Title?: string;
    Img?: string;
}
export declare class Team implements ITeam {
    Id?: number;
    Title?: string;
    Img?: string;
    constructor(Id?: number, Title?: string, Img?: string);
}
