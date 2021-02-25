export interface ITeam {
    Id?:number;
    Title?:string;
    Img?:string;
}

export  class Team implements ITeam{
    constructor(
        public Id?:number,
        public Title?:string,
        public Img?:string
    ) {
    }
}