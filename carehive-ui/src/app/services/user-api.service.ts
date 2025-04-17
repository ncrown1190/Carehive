import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {
  baseUrl = 'https://localhost:7115/api';
  //apiurl = 'https://localhost:7269/api';


  constructor(private http: HttpClient) { }

   //authenticate user
   getUser(user: any): Observable<any> {
    console.log('user login/authenticate service called');
    return this.http.post(`${this.baseUrl}/Users/Authenticate`, user);
  }
}
