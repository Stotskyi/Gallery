import { Component, NgModule } from '@angular/core';
import { LoginRequest } from '../models/login-request.model';
import { FormsModule, NgModel } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: LoginRequest;

 
  constructor(private authService: AuthService) {
    this.model = {
      username: '',
      password: ''
    };
  }

  onFormSubmit(): void{
    this.authService.login(this.model)
    .subscribe({
      next: (response) =>{
        console.log(response);
      }
    })
  }
}
