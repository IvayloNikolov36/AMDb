import { ActorConcise } from './../../core/models/actor-concise';
import { ActorsService } from './../../core/services/actors/actors.service';
import { Observable } from 'rxjs';
import { MovieConcise } from './../../core/models/movie-concise';
import { Component, OnInit } from '@angular/core';
import { MoviesService } from 'src/app/core/services/movies/movies.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  thisMonthMovies$: Observable<MovieConcise[]>;
  bornTodayActors$: Observable<ActorConcise[]>;

  constructor(
    private movies: MoviesService,
    private actors: ActorsService
  ) { }

  ngOnInit() {
    this.thisMonthMovies$ = this.movies.getThisMonth();
    this.bornTodayActors$ = this.actors.getBornToday();
  }

}
