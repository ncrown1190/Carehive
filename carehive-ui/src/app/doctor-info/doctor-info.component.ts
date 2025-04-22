import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-doctor-info',
  imports: [CommonModule],
  templateUrl: './doctor-info.component.html',
  styleUrl: './doctor-info.component.css'
})
export class DoctorInfoComponent {
name: string = "Dr. Syeda Hussain";
role: string = "Family Medicine";

}
