import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieListComponent } from './movies/movie-list/movie-list.component';
import { MenuComponent } from './menu/menu.component';
import { GenericListComponent } from './utilities/generic-list/generic-list.component';
import { RatingComponent } from './utilities/rating/rating.component';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [
    MovieListComponent,
    MenuComponent,
    GenericListComponent,
    RatingComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    MovieListComponent,
    MenuComponent,
    GenericListComponent,
    RatingComponent
  ],
})
export class ComponentsModule { }
