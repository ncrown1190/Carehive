import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-medical-history',
  imports: [CommonModule],
  templateUrl: './medical-history.component.html',
  styleUrl: './medical-history.component.css'
})
export class MedicalHistoryComponent {
  Patient: string = 'Priy Ajay';
doctor: string = 'Dr. Syeda Hussain';
// email: string = 'ajay&#64;gmail.com';
email: string = 'ajay@gmail.com';

}
