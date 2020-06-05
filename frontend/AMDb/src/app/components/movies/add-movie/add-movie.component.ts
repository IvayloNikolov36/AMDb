import { MoviesService } from './../../../core/services/movies/movies.service';

import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent implements OnInit {
  addMovieForm: FormGroup;

  constructor(
    private movies: MoviesService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.addMovieForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      duration: ['', [Validators.required, Validators.min(0.2), Validators.max(5.0)]],
      releaseDate: ['', Validators.nullValidator],
      genre: ['', [Validators.required]],
      imageUrl: ['', [Validators.required]]
    });
  }

  publishMovie() {
    this.movies.add(this.addMovieForm.value).subscribe((data) => {
      this.router.navigate(['/home']);
    });
  }

  get f() {
    return this.addMovieForm.controls;
  }
}
