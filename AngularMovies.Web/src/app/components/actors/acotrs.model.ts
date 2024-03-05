export interface actorCreationDto extends actorBaseDto{
    picture: File;
}

export interface actorDto extends actorBaseDto{    
    picture: string;
}

export interface actorBaseDto{
    name: string;
    dateOfBirth: Date;
    biography: string;
}