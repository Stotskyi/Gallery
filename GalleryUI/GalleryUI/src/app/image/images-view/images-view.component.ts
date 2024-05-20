import { Component, OnInit } from '@angular/core';
import { ImageViewComponent } from "../image-view/image-view.component";
import { ImageService } from '../services/image.service';
import { CommonModule } from '@angular/common';
import { ImageDto } from '../models/image-dto.model';
import { Observable } from 'rxjs';
import { ImageModalComponent } from "../image-modal/image-modal.component";

@Component({
    selector: 'app-images-view',
    standalone: true,
    templateUrl: './images-view.component.html',
    styleUrl: './images-view.component.css',
    imports: [ImageViewComponent, CommonModule, ImageModalComponent]
})
export class ImagesViewComponent implements OnInit{
  images: ImageDto[] = [];
  modalImage?: string;

  constructor(private imageUrlService: ImageService) { }

  ngOnInit(): void {
    this.getImages();
  }
  private getImages(){
    this.imageUrlService.getAllImages().subscribe(data  => {
      this.images = data;
    });
    
  }
  openModal(imageUrl: string): void {
    this.modalImage = imageUrl;
  }

  closeModal(): void {
    this.modalImage = '';
  }
  
}