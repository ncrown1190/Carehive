import { Component, OnInit } from '@angular/core';
import { Appointment } from '../../../models/appointment.model';
import { ApiService } from '../../../services/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-doctor-appoint-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './doctor-appoint-list.component.html',
  styleUrl: './doctor-appoint-list.component.css',
})
export class DoctorAppointListComponent implements OnInit {
  appointments: Appointment[] = [];
  doctorName: string = '';

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {}
  fetchDocAppointments(): void {
    if (this.doctorName.trim()) {
      this.apiService
        .getAppointmentsByDoctor(this.doctorName)
        .subscribe((data: Appointment[]) => {
          console.log(data);
          this.appointments = data;
        });
    }
  }
}
