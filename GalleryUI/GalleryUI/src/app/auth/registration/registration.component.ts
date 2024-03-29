import { Component } from '@angular/core';
import { RegistrationRequest } from '../models/registration-request.model';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  model: RegistrationRequest;

  constructor(private authService: AuthService,private cookieService: CookieService, private router: Router) {
    this.model = {
      username: '',
      email: '',
      password: ''
    };
  }

  onFormSubmit(): void{
    this.authService.registration(this.model)
    .subscribe({
      next: (response) =>{
         this.cookieService.set('Authorization',`Bearer ${response.accessToken}`,
        undefined,'/',undefined,true,'Strict');

        this.router.navigateByUrl('/');
      }
    })
  }

}
