import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { movieCreationDto, movieDto } from '../movies.model';

@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css']
})
export class EditMovieComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute){}

  model: movieDto = {
                        title: 'Spider-Man', 
                        inTheaters: true, 
                        summary: 'whatever', 
                        releaseDate: new Date(), 
                        trailer: 'Trailer YouTube Link', 
                        poster: 'https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png'
                     };

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      
    });
  }

  saveChanges(movieCreationDto: any){

  }
}
