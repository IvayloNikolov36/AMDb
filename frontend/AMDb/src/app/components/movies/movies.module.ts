import { MoviesService } from './../../core/services/movies/movies.service';
import { AddMovieComponent } from './add-movie/add-movie.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';

const routes: Routes = [
  { path: 'add', component: AddMovieComponent }
];

@NgModule({
  declarations: [
    AddMovieComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    FlexLayoutModule,
    RouterModule.forChild(routes),
  ],
  providers: [
    MoviesService
  ]
})
export class MoviesModule { }
