import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-patient-dashboard',
  imports: [CommonModule, RouterLink, RouterOutlet, FormsModule],
  templateUrl: './patient-dashboard.component.html',
  styleUrl: './patient-dashboard.component.css'
})
export class PatientDashboardComponent {
  users: User[] = [];
  user: User = {
      userId: 0,
      name: '',
      loginId: '',
      passwordHash: '',
      email: '',
      role: '',
    };
    toggle: boolean = true;
  
    constructor(private router: Router) {}
  
    ngOnInit(): void {
      this.user = JSON.parse(localStorage.getItem('user')!);
      console.log('in home', this.user);
    }
  
    Logout() {
      localStorage.removeItem('myToken');
      this.router.navigate(['/login', { success: 'Logged out successfully' }]);
    }
  
}
