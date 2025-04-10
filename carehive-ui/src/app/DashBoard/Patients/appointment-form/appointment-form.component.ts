import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CreateAppointment } from '../../../models/createAppointment.model';
import { NewApiService } from '../../../services/new-api.service';

@Component({
  selector: 'app-appointment-form',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './appointment-form.component.html',
  styleUrl: './appointment-form.component.css'
})
export class AppointmentFormComponent {
  appointmentForm: FormGroup;
  appointmentList: CreateAppointment[] = [];

  patientAppointment: CreateAppointment = {
    patientId: 0,
    doctorId: 0,
    appointmentDate: '',
    appointmentTime: '',
    status: '',
  };

  fb = inject(FormBuilder)

  constructor(private newApiService: NewApiService){
    this.appointmentForm = this.fb.group({
      patientId: ['', [Validators.required]],
      doctorId: ['', [Validators.required]],
      appointmentDate: ['', [Validators.required]],
      appointmentTime: ['', [Validators.required]],
      status:['pending'] 
    });
  }
  onSubmit(){
    if(this.appointmentForm.valid){
     this.newApiService.createAppointment(this.appointmentForm.value).subscribe((data: any) => {
      this.appointmentList.push(data);
     })
      console.log('Form submitted', this.appointmentForm.value);
      this.appointmentForm.reset();
    }
  }

}
