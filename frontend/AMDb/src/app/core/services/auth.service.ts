import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = 'https://localhost:44371/api/';
  private readonly loginUrl = this.apiUrl + 'login';
  private readonly registerUrl = this.apiUrl + 'register';

  constructor(private http: HttpClient) { }

  register(body) {
    return this.http.post(this.registerUrl, body);
  }

  login(body) {
    return this.http.post(this.loginUrl, body);
  }

  logout() {
    localStorage.clear();
  }

  isAuthenticated() {
    return localStorage.getItem('token') !== null;
  }

  isAdmin() {
    return localStorage.getItem('isAdmin') === 'true';
  }

  getToken() {
    const token = localStorage.getItem('token');
    return token;
  }

}
