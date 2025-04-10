import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DoctorsID } from '../../../models/doctorsId.model';
import { NewApiService } from '../../../services/new-api.service';

@Component({
  selector: 'app-doctors-id',
  imports: [CommonModule, FormsModule],
  templateUrl: './doctors-id.component.html',
  styleUrl: './doctors-id.component.css'
})
export class DoctorsIdComponent implements OnInit{
doctors: DoctorsID[]= [];

constructor(private newApiService: NewApiService){}

ngOnInit(): void {
  this.getDoctorsId();
}

getDoctorsId(): void{
  this.newApiService.getAllDoctorsId().subscribe((data: DoctorsID[]) => {
    this.doctors = data;
  })
}

}
