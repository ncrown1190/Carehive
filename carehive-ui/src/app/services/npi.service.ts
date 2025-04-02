import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NpiService {
  private apiUrl =
    'https://clinicaltables.nlm.nih.gov/api/npi_org/v3/search?state=MI&city=Detroit';

  constructor(private http: HttpClient) {}

  searchNpi(term: string): Observable<any[]> {
    return this.http.get<any>(this.apiUrl, { params: { term: term } }).pipe(
      map((response: any) => response[3]) // Extract the table data
    );
  }
}
