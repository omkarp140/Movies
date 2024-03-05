import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit { 

  ngOnInit(): void {
  }

  @Input()
  movies: { title: string; poster: string }[] | undefined;

  remove(index: number){
    this.movies?.splice(index, 1);
  }

}
