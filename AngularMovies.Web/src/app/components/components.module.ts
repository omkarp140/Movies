import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieListComponent } from './movies/movie-list/movie-list.component';
import { MenuComponent } from './menu/menu.component';
import { GenericListComponent } from './utilities/generic-list/generic-list.component';
import { RatingComponent } from './utilities/rating/rating.component';
import { MaterialModule } from '../material/material.module';
import { HomeComponent } from './home/home.component';
import { IndexGenresComponent } from './genres/index-genres/index-genres.component';
import { RouterModule } from '@angular/router';
import { CreateGenreComponent } from './genres/create-genre/create-genre.component';
import { IndexActorsComponent } from './actors/index-actors/index-actors.component';
import { IndexMovieTheaterComponent } from './movie-theaters/index-movie-theater/index-movie-theater.component';
import { CreateMovieTheaterComponent } from './movie-theaters/create-movie-theater/create-movie-theater.component';
import { CreateMovieComponent } from './movies/create-movie/create-movie.component';
import { CreateActorsComponent } from './actors/create-actors/create-actors.component';
import { EditActorComponent } from './actors/edit-actor/edit-actor.component';
import { EditGenreComponent } from './genres/edit-genre/edit-genre.component';
import { EditMovieTheaterComponent } from './movie-theaters/edit-movie-theater/edit-movie-theater.component';
import { EditMovieComponent } from './movies/edit-movie/edit-movie.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FormGenreComponent } from './genres/form-genre/form-genre.component';
import { MovieFilterComponent } from './movies/movie-filter/movie-filter.component';
import { FormActorComponent } from './actors/form-actor/form-actor.component';
import { InputImgComponent } from './utilities/input-img/input-img.component';
import { InputMarkdownComponent } from './utilities/input-markdown/input-markdown.component';
import { MarkdownModule } from 'ngx-markdown';
import { MovieTheaterFormComponent } from './movie-theaters/movie-theater-form/movie-theater-form.component';
import { LeafletModule } from '@asymmetrik/ngx-leaflet';
import { MapComponent } from './utilities/map/map.component';

@NgModule({
  declarations: [
    MovieListComponent,
    MenuComponent,
    GenericListComponent,
    RatingComponent,
    HomeComponent,
    IndexGenresComponent,
    CreateGenreComponent,
    IndexActorsComponent,
    IndexMovieTheaterComponent,
    CreateMovieTheaterComponent,
    CreateMovieComponent,
    CreateActorsComponent,
    EditActorComponent,
    EditGenreComponent,
    EditMovieTheaterComponent,
    EditMovieComponent,
    FormGenreComponent,
    MovieFilterComponent,
    FormActorComponent,
    InputImgComponent,
    InputMarkdownComponent,
    MovieTheaterFormComponent,
    MapComponent,    
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    LeafletModule,
    MarkdownModule.forRoot()
  ],
  exports: [
    MovieListComponent,
    MenuComponent,
    GenericListComponent,
    RatingComponent
  ],
})
export class ComponentsModule { }
