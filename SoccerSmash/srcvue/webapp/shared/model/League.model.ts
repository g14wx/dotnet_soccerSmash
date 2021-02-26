export interface ILeague{
    Id?: number;
    Title?: string;
}

export class League implements ILeague{

    constructor(
        public Id?: number,
        public Title?: string
    ) {
    }
}