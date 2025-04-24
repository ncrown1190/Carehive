import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, Observable, switchMap } from 'rxjs';
import { DoctorsData } from '../models/doctor.model';
import { NpiService } from '../services/npi.service';
import { CommonModule } from '@angular/common';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-doctor-search',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './doctor-search.component.html',
  styleUrl: './doctor-search.component.css',
})
export class DoctorSearchComponent implements OnInit {
  searchControl = new FormControl();
  filteredResults$: Observable<any[]> | undefined;
  query: string = '';
  results: DoctorsData[] = [];
  url: any;

  constructor(private npiService: NpiService, private domSanitizer: DomSanitizer) {}
  ngOnInit() {
    this.filteredResults$ = this.searchControl.valueChanges.pipe(
      debounceTime(300),
      switchMap((searchTerm: string) => this.npiService.searchNpi(searchTerm))
    );    
  }

}
