import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  moviesInTheaters: { title: string; releaseDate: Date; price: number; }[] | undefined;
  moviesFutureReleases: { title: string; releaseDate: Date; price: number; }[] | undefined;
  
  ngOnInit(): void {
    setTimeout(() => {
      this.moviesInTheaters = [{
        title : 'Spider-Man',
        releaseDate: new Date(),
        price: 1400.99
      },
      {
        title : 'Iron-Man',
        releaseDate: new Date(),
        price: 1500.99
      },
      {
        title : 'Ant-Man',
        releaseDate: new Date(),
        price: 1600.99
      }];

      this.moviesFutureReleases = [{
        title : 'A-Man',
        releaseDate: new Date(),
        price: 1400.99
      },
      {
        title : 'B-Man',
        releaseDate: new Date(),
        price: 1500.99
      },
      {
        title : 'C-Man',
        releaseDate: new Date(),
        price: 1600.99
      }];
    }, 3000);
  } 

  title = 'My first angular app';

  handleRating(rating: number){
    alert(`The user selected ${rating}`);
  }
}
