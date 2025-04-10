import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Appointment } from '../models/appointment.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'https://localhost:7115/api';

  constructor(private http: HttpClient) { }

  //for patients to search their appointments
  getAppointmentsByPatient(patientName: string): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(
      `${this.baseUrl}/Appointments/patient?patientName=${patientName}`
    );
  }
  //get doctor Appointment
  getDoctorAppointments(): Observable<Appointment[]>{
    return this.http.get<Appointment[]>(`${this.baseUrl}/Appointments/doctor-patient-mappings`);
  }

  getAppointmentsByDoctor(doctorName: string): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.baseUrl}/Appointments/doctor?doctorName=${doctorName}`)
  }
}
