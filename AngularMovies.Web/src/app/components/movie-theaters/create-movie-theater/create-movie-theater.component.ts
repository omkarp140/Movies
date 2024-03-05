import { Component } from '@angular/core';
import { movieTheaterCreationDto } from '../movie-theaters.model';

@Component({
  selector: 'app-create-movie-theater',
  templateUrl: './create-movie-theater.component.html',
  styleUrls: ['./create-movie-theater.component.css']
})
export class CreateMovieTheaterComponent {

  saveChanges(movieTheater: movieTheaterCreationDto){
    console.log(movieTheater);
  }

}
