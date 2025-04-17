import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CreateDoctor } from '../../../models/createDoctor.model';
import { NewApiService } from '../../../services/new-api.service';

@Component({
  selector: 'app-add-doctors',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-doctors.component.html',
  styleUrl: './add-doctors.component.css'
})
export class AddDoctorsComponent {
  addDoctorForm: FormGroup;
  DoctorList: CreateDoctor[] = [];

  fb = inject(FormBuilder)

  constructor(private newApiService: NewApiService){
    this.addDoctorForm = this.fb.group({
      userId: ['', [Validators.required]],
      specialty: ['', [Validators.required]],
    });
  }
  onSubmit(){
    if(this.addDoctorForm.valid){
     
    }
  }
}
