import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { ImageService } from '../services/image.service';

@Component({
  selector: 'app-image-uploader',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './image-uploader.component.html',
  styleUrl: './image-uploader.component.css'
})
export class ImageUploaderComponent {
  private file?: File;
  filename: string = '';


  constructor(private imageService: ImageService) {
   
  }

onFileUploaderChange(event: Event) : void {
  const element = event.currentTarget as HTMLInputElement;
  this.file = element.files?.[0];
}
uploadImage():void{
  if(this.file && this.filename !== ''){
this.imageService.uploadImage(this.file, this.filename)
.subscribe({
  next: (response) =>{
    console.log(response);
  }
});
  }
}
}
