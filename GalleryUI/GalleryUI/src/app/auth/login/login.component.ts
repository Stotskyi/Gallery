import { Component, NgModule } from '@angular/core';
import { LoginRequest } from '../models/login-request.model';
import { FormsModule, NgModel } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: LoginRequest;

 
  constructor(private authService: AuthService,private cookieService: CookieService, private router: Router) {
    this.model = {
      username: '',
      password: ''
    };
  }

  onFormSubmit(): void{
    this.authService.login(this.model)
    .subscribe({
      next: (response) =>{
         this.cookieService.set('Authorization',`Bearer ${response.accessToken}`,
        undefined,'/',undefined,true,'Strict');
        console.log(response.accessToken)
        this.router.navigateByUrl('/');
      }
    })
  }
}
