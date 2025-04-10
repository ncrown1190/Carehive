import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { Appointment } from '../../../models/appointment.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-patient-appointment',
  imports: [CommonModule, FormsModule],
  templateUrl: './patient-appointment.component.html',
  styleUrl: './patient-appointment.component.css',
})
export class PatientAppointmentComponent implements OnInit {
  appointments: any[] = [];
  patientName: string = '';

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {}

  fetchAppointments(): void {
    if (this.patientName.trim()) {
      this.apiService
        .getAppointmentsByPatient(this.patientName)
        .subscribe((data: Appointment[]) => {
          this.appointments = data;
        });
    }
  }
}
