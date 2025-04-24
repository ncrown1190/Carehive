import { Component } from '@angular/core';
import { Schedule } from '../models/scheDoctor.model';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-doctor-schedule',
  imports: [CommonModule, FormsModule],
  templateUrl: './doctor-schedule.component.html',
  styleUrl: './doctor-schedule.component.css',
})
export class DoctorScheduleComponent {
  docName: string = '';
  schedules: Schedule[] = [];
  showSearch: boolean = true;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {}

  getScheByDoctor() {
    if (this.docName) {
      this.apiService
        .getScheduleByDocName(this.docName)
        .subscribe((data: any) => {
          this.schedules = data;
        });
       //this.docName = '';
    }
    
  }
  

  // toggleSearch() {
  //   this.showSearch = !this.showSearch; // Toggles visibility
  // }
}
