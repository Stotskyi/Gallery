import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/login-request.model';
import { Observable } from 'rxjs';
import { LoginResponse } from '../models/login-response.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { RegistrationRequest } from '../models/registration-request.model';
import { RegistrationResponse } from '../models/registration-response.model';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(request: LoginRequest) : Observable<LoginResponse>{
    return this.http.post<LoginResponse>(`${environment.API_URL}/sign-in`, {
      username: request.username,
      password: request.password
    });
  }

  registration(request: RegistrationRequest) : Observable<RegistrationResponse>{
    return this.http.post<RegistrationResponse>(`${environment.API_URL}/sign-up`,{
      username: request.username,
      email: request.email,
      password: request.password
    })
  }

}
