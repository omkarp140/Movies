import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-movie-filter',
  templateUrl: './movie-filter.component.html',
  styleUrls: ['./movie-filter.component.css']
})

export class MovieFilterComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) {}
  
  form!: FormGroup;

  genres = [
    {id: 1, name: 'Drama'},
    {id: 2, name: 'Action'},
    {id: 3, name: 'Comedy'},
    {id: 4, name: 'Thriller'},
    {id: 5, name: 'Sci-Fi'}
  ];
  
  movies =[
    {
      title : 'Spider-Man',
      poster: 'https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png'
    },
    {
      title : 'Iron-Man',
      poster: 'https://upload.wikimedia.org/wikipedia/en/thumb/4/47/Iron_Man_%28circa_2018%29.png/220px-Iron_Man_%28circa_2018%29.png'
    },
    {
      title : 'Ant-Man',
      poster: 'https://upload.wikimedia.org/wikipedia/en/1/12/Ant-Man_%28film%29_poster.jpg'
    }
  ];

  originalMovies = this.movies;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      title: '',
      genreId: 0,
      upcomingReleases: false,
      inTheaters: false
    });

    this.form.valueChanges.subscribe(values => {
      this.movies = this.originalMovies;
      this.filterMovies(values);
    });
  }

  filterMovies(values: any){
    if(values.title){
      this.movies = this.movies.filter(m => m.title.indexOf(values.title) !== -1)
    }

  }

  clearForm() {
    this.form.reset();
  }
}
