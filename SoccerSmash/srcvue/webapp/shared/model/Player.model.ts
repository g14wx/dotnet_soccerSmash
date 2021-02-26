export interface IPlayer{
    Id?:number,
    Name?:String,
    NShirt?:number,
    Age?:number,
    Img?:String,
    Stature?:number,
    Weight?: number,
    IdUniversity?:number,
    IdTeam?:number,
    IdPosition?:number,
}

export class Player implements IPlayer{
    constructor(
        public Id?:number,
        publicName?:String,
        NpublicShirt?:number,
        public Age?:number,
        public Img?:String,
        public Stature?:number,
        public Weight?: number,
        public IdUniversity?:number,
        public IdTeam?:number,
        public IdPosition?:number,
    ) {
    }
}