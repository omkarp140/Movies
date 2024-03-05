export interface movieCreationDto extends movieBaseDto {
    poster: File;
}

export interface movieDto extends movieBaseDto{
    poster: string;
}

export interface movieBaseDto{
    title: string;
    summary: string;
    inTheaters: boolean;
    releaseDate: Date;
    trailer: string;
}