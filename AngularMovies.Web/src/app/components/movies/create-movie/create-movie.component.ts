import { Component } from '@angular/core';
import { movieCreationDto } from '../movies.model';

@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css']
})
export class CreateMovieComponent {

  saveChanges(movieCreationDto: movieCreationDto){
    console.log(movieCreationDto);
  }
}
