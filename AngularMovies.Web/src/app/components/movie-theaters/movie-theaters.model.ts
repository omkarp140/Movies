export interface movieTheaterCreationDto extends movieTheaterBaseDto{
}

export interface movieTheaterDto extends movieTheaterBaseDto{    
}

export interface movieTheaterBaseDto{
    name: string;
    latitude: number;
    longitude: number;
}