import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-doctor-dashboard',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './doctor-dashboard.component.html',
  styleUrl: './doctor-dashboard.component.css',
})
export class DoctorDashboardComponent {
  users: User[] = [];
  user: User = {
    userId: 0,
    name: '',
    loginId: '',
    passwordHash: '',
    email: '',
    role: '',
  };

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
