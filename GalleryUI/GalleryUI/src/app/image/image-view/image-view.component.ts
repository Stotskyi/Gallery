import { Component, Input } from '@angular/core';
import { ImageService } from '../services/image.service';
import { OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ImageDto } from '../models/image-dto.model';

@Component({
  selector: 'app-image-view',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './image-view.component.html',
  styleUrl: './image-view.component.css'
})
export class ImageViewComponent {
  @Input()
  image?: string;
}
