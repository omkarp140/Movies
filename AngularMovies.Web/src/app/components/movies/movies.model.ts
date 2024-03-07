export interface movieCreationDto extends movieBaseDto {
    poster: File;
    genreIds: number[];
    movieTheaterIds: number[];
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