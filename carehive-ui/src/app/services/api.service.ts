import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { CreateUser } from '../models/createuser.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'https://localhost:7115/api';

  constructor(private http: HttpClient) { }

  //authenticate user
  getUser(user: any): Observable<any> {
    console.log('user login/authenticate service called');
    return this.http.post(`${this.baseUrl}/Users/Authenticate`, user);
  }

   //Create User
   createUser(user: CreateUser) {
    console.log('called Create user from api service', user);
    return this.http.post(`${this.baseUrl}/Users/register`, user);
  }

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

  getScheduleByDocName(docName: string): Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/Schedules/${docName}`)
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

}
