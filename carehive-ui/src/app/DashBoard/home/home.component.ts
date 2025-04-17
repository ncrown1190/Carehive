import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../../models/user.model';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [CommonModule, FormsModule, RouterOutlet,RouterLink, RouterLinkActive],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  user: User = {
    userId: 0,
    name: '',
    loginId: '',
    passwordHash: '',
    email: '',
    role: '',
  };

  errorMessage = '';

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user')!);
    console.log('in home', this.user);
    if (this.user.role === 'Doctor') {
      this.router.navigateByUrl('/doctorDashboard');
    }else if(this.user.role === 'Patient'){
      this.router.navigateByUrl('/patientDashboard');
    } 
    else {
      this.router.navigateByUrl('/adminDashboard');
    }
  }

  Logout() {
    localStorage.removeItem('myToken');
    this.router.navigate(['/login', { success: 'Logged out successfully' }]);
  }

}
