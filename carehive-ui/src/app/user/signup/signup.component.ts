import { Component } from '@angular/core';
import { CreateUser } from '../../models/createuser.model';
import { ApiService } from '../../services/api.service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-signup',
  imports: [CommonModule, FormsModule,RouterLink],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  user: CreateUser = {
    userId: 0,
    UserName: '',
    loginId: '',
    passwordHash: '',
    email: '',
    phone: '',
    role: '',
    address: '',
  };

  errorMessage = '';

  constructor(private apiService: ApiService, private router: Router) {}

  CreateUser() {
    console.log('Create user called', this.user);
    var message = this.apiService.createUser(this.user).subscribe({
      next: (data) => {
        console.log('User created successfully', data);

        this.router.navigate([
          '/login',
          { success: 'User created successfully' },
        ]);
      },
      error: (error) => {
        this.errorMessage = error.error;
        //console.log('Error creating user', error);
      },
    });    
  }

  Cancel() {
    this.router.navigateByUrl('/login');
  }

}
