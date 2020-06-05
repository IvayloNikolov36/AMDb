import { MovieConcise } from './../../models/movie-concise';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movie } from '../../models/movie';

const baseUrl = 'https://localhost:44371/api/movies/';
const addMovieUrl = baseUrl + 'publish';
const thisMonthUrl = baseUrl + 'this-month';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  private userToken: string;

  constructor(private http: HttpClient) {
    this.userToken = localStorage.getItem('token');
   }

  add(data: Movie) {
    return this.http.post(addMovieUrl, data);
  }

  getThisMonth(): Observable<MovieConcise[]> {
    return this.http.get<MovieConcise[]>(thisMonthUrl);
  }

}
