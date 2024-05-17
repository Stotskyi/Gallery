import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-image-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './image-modal.component.html',
  styleUrl: './image-modal.component.css'
})
export class ImageModalComponent {
  @Input() imageUrl: string | undefined;
  showModal: boolean = false;

  toggleModal(): void {
    this.showModal = !this.showModal;
  }
}
