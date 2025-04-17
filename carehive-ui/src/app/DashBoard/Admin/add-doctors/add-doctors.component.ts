import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CreateDoctor } from '../../../models/createDoctor.model';
import { NewApiService } from '../../../services/new-api.service';
import { AddDoctor } from '../../../models/addDoctor.model';

@Component({
  selector: 'app-add-doctors',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-doctors.component.html',
  styleUrl: './add-doctors.component.css'
})
export class AddDoctorsComponent {
  addDoctorForm: FormGroup;
  doctorList: AddDoctor[] = [];

  newDoctor: AddDoctor = {
    userId: 0,
    doctorName: '',
    specialty: '',
  };

  fb = inject(FormBuilder);

  constructor(private newApiService: NewApiService) {
    this.addDoctorForm = this.fb.group({
      doctorName: ['', [Validators.required]],
      specialty: ['', [Validators.required]],
    });
  }
  onSubmit(){
    if(this.addDoctorForm.valid){
     this.newApiService.addDoctors(this.addDoctorForm.value).subscribe((data: any) => {
      this.doctorList.push(data);
     })
      console.log('Form submitted', this.addDoctorForm.value);
      this.addDoctorForm.reset();
    }
  }
}
