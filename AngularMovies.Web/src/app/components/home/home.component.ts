import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  moviesInTheaters: { title: string; releaseDate: Date; price: number; poster: string; }[] | undefined;
  moviesFutureReleases: { title: string; releaseDate: Date; price: number; poster: string; }[] | undefined;

  ngOnInit(): void {
    setTimeout(() => {
      this.moviesInTheaters = [{
        title : 'Spider-Man',
        releaseDate: new Date(),
        price: 1400.99,
        poster: 'https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png'
      },
      {
        title : 'Iron-Man',
        releaseDate: new Date(),
        price: 1500.99,
        poster: 'https://upload.wikimedia.org/wikipedia/en/thumb/4/47/Iron_Man_%28circa_2018%29.png/220px-Iron_Man_%28circa_2018%29.png'
      },
      {
        title : 'Ant-Man',
        releaseDate: new Date(),
        price: 1600.99,
        poster: 'https://upload.wikimedia.org/wikipedia/en/1/12/Ant-Man_%28film%29_poster.jpg'
      }];

      this.moviesFutureReleases = [{
        title : 'S-Man',
        releaseDate: new Date(),
        price: 1400.99,
        poster: 'https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png'
      },
      {
        title : 'I-Man',
        releaseDate: new Date(),
        price: 1500.99,
        poster: 'https://upload.wikimedia.org/wikipedia/en/thumb/4/47/Iron_Man_%28circa_2018%29.png/220px-Iron_Man_%28circa_2018%29.png'
      },
      {
        title : 'A-Man',
        releaseDate: new Date(),
        price: 1600.99,
        poster: 'https://upload.wikimedia.org/wikipedia/en/1/12/Ant-Man_%28film%29_poster.jpg'
      }];
    }, 3000);
  } 

}
