export interface IPlayer {
    Id?: number;
    Name?: String;
    NShirt?: number;
    Age?: number;
    Img?: String;
    Stature?: number;
    Weight?: number;
    IdUniversity?: number;
    IdTeam?: number;
    IdPosition?: number;
}
export declare class Player implements IPlayer {
    Id?: number;
    Age?: number;
    Img?: String;
    Stature?: number;
    Weight?: number;
    IdUniversity?: number;
    IdTeam?: number;
    IdPosition?: number;
    constructor(Id?: number, publicName?: String, NpublicShirt?: number, Age?: number, Img?: String, Stature?: number, Weight?: number, IdUniversity?: number, IdTeam?: number, IdPosition?: number);
}
