import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateAppointment } from '../models/createAppointment.model';
import { Observable } from 'rxjs';
import { DoctorsID } from '../models/doctorsId.model';
import { CreateDoctor } from '../models/createDoctor.model';

@Injectable({
  providedIn: 'root',
})
export class NewApiService {
  baseUrl = 'https://localhost:7115/api';
  //https://localhost:7115/api/Appointments/book-appointment

  constructor(private http: HttpClient) {}

  createAppointment(patientInfo: CreateAppointment) {
    console.log('create user from api service', patientInfo);
    return this.http.post(`${this.baseUrl}/Appointments/book-appointment`, patientInfo);
  }

  getAllDoctorsId(): Observable<DoctorsID[]> {
    return this.http.get<DoctorsID[]>(`${this.baseUrl}/Doctors`);
  }

  addDoctors(doctorInfo: CreateDoctor) {
    console.log('create  from api service', doctorInfo);
    return this.http.post(`${this.baseUrl}/Doctors`, doctorInfo);
  }
}
