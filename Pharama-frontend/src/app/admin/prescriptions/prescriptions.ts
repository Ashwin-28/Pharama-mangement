import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-prescriptions',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './prescriptions.html',
  styleUrls: ['./prescriptions.css']
})
export class Prescriptions {
  // In a real application, fetching uploaded prescriptions would happen here.
  prescriptionsList: string[] = [
    'Example_Prescription_1.jpg',
    'Example_Prescription_2.pdf'
  ];

  baseUrl = 'https://localhost:7146/Uploads/';

  constructor() {}
}
