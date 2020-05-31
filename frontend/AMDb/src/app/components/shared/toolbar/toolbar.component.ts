import { AuthService } from './../../../core/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {
  isAuth: boolean;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isAuth = this.authService.isAuthenticated();
  }

  logout() {
    this.authService.logout();
  }
}
