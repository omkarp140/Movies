import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { IndexGenresComponent } from './components/genres/index-genres/index-genres.component';
import { CreateGenreComponent } from './components/genres/create-genre/create-genre.component';
import { IndexActorsComponent } from './components/actors/index-actors/index-actors.component';
import { CreateActorsComponent } from './components/actors/create-actors/create-actors.component';
import { IndexMovieTheaterComponent } from './components/movie-theaters/index-movie-theater/index-movie-theater.component';
import { CreateMovieComponent } from './components/movies/create-movie/create-movie.component';
import { CreateMovieTheaterComponent } from './components/movie-theaters/create-movie-theater/create-movie-theater.component';
import { EditActorComponent } from './components/actors/edit-actor/edit-actor.component';
import { EditGenreComponent } from './components/genres/edit-genre/edit-genre.component';
import { EditMovieTheaterComponent } from './components/movie-theaters/edit-movie-theater/edit-movie-theater.component';
import { EditMovieComponent } from './components/movies/edit-movie/edit-movie.component';

const routes: Routes = [
  {path: '', component: HomeComponent},

  {path: 'genres', component: IndexGenresComponent},
  {path: 'genres/create', component: CreateGenreComponent},
  {path: 'genres/edit/:id', component: EditGenreComponent},

  {path: 'actors', component: IndexActorsComponent},
  {path: 'actors/create', component: CreateActorsComponent},
  {path: 'actors/edit/:id', component: EditActorComponent},

  {path: 'movietheaters', component: IndexMovieTheaterComponent},
  {path: 'movietheaters/create', component: CreateMovieTheaterComponent},
  {path: 'movietheaters/edit/:id', component: EditMovieTheaterComponent},

  {path: 'movies/create', component: CreateMovieComponent},
  {path: 'movies/edit/:id', component: EditMovieComponent},

  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
