import { Injectable } from '@angular/core';
import { genreDto } from './genres.models';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  constructor(private httpClient: HttpClient) { }
  private apiUrl = environment.apiUrl + "/genres";

  getAll(): Observable<genreDto[]>{
    return this.httpClient.get<genreDto[]>(this.apiUrl);
  }
}
