export interface iUniversity{
    Id?:number,
    Title?: string
}

export class University{
    constructor(
       public Id?:number,
        public Title?: string
    ) {
       
    }

}