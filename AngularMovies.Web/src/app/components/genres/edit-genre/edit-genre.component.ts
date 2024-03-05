import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { genreCreationDto } from '../genres.models';

@Component({
  selector: 'app-edit-genre',
  templateUrl: './edit-genre.component.html',
  styleUrls: ['./edit-genre.component.css']
})
export class EditGenreComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute){}

  model: genreCreationDto = {name: 'Drama'};

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      
    });
  }

  saveChanges(genreCreationDto: genreCreationDto) {
    
  }
}
