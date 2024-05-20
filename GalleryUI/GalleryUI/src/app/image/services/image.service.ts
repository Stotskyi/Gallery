import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { CookieService } from 'ngx-cookie-service';
import { ImageDto } from '../models/image-dto.model';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  getAllImages() : Observable<ImageDto[]>{
     return this.http.get<ImageDto[]>(`${environment.API_URL}/Image/getAll`,{
      headers:{
        'Authorization': this.cookieService.get('Authorization')
      }
     });
  }

  uploadImage(file: File,filename: string) : Observable<string>{
    const formData = new FormData();
    formData.append('file',file);
    formData.append('filename',filename);

    return this.http.post<string>(`${environment.API_URL}/Image/upload`,formData ,{
      headers:{
        'Authorization': this.cookieService.get('Authorization')
      }
    });
  }
}
