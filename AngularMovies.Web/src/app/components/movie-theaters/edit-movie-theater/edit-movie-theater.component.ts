import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { movieTheaterCreationDto, movieTheaterDto } from '../movie-theaters.model';

@Component({
  selector: 'app-edit-movie-theater',
  templateUrl: './edit-movie-theater.component.html',
  styleUrls: ['./edit-movie-theater.component.css']
})
export class EditMovieTheaterComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute){}

  model: movieTheaterDto = {name: 'Pune', latitude:1, longitude: 1};

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      
    });
  }

  saveChanges(movieTheater: movieTheaterCreationDto){

  }
}
