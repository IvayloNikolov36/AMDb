import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  login() {
    this.authService
      .login(this.form.value)
      .subscribe((data) => {
        const token = data['token'];
        localStorage.setItem('token', token);

        const name = data['username'];
        localStorage.setItem('username', name);

        const isAdmin = data['role'] === 'Admin' ? true : false;
        localStorage.setItem('isAdmin', String(isAdmin));

        const isCompany = data['role'] === 'Company' ? true : false;
        localStorage.setItem('isCompany', String(isCompany));

        this.router.navigate(['/home']);
      });
  }

  get f() {
    return this.form.controls;
  }
}
