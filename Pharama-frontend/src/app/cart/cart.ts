import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileService } from '../services/file';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.html',
  styleUrls: ['./cart.css']
})
export class Cart {
  selectedFile: File | null = null;
  uploadedFileName: string = '';

  constructor(private fileService: FileService) {}

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onUpload() {
    if (this.selectedFile) {
      this.fileService.uploadPrescription(this.selectedFile).subscribe({
        next: (response) => {
          this.uploadedFileName = response.fileName;
          alert('File uploaded successfully!');
        },
        error: (err) => {
          console.error(err);
          alert('File upload failed.');
        }
      });
    }
  }
}
