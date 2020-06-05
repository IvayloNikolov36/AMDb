import { Observable } from 'rxjs';
import { Actor } from './../../models/actor';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const baseUrl = 'https://localhost:44371/api/actors/';
const addUrl = baseUrl + 'add';
const bornTodayUrl = baseUrl + 'born-today';

@Injectable({
  providedIn: 'root'
})
export class ActorsService {
  private userToken: string;

  constructor(private http: HttpClient) { }

  add(data: Actor) {
    return this.http.post(addUrl, data);
  }

  getBornToday(): Observable<Actor[]> {
    return this.http.get<Array<Actor>>(bornTodayUrl);
  }

}
