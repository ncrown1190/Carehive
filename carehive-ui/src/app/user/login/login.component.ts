import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { User } from '../../models/user.model';
import { UserApiService } from '../../services/user-api.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  user: User = {
    userId: 0,
    name: '',
    loginId: '',
    passwordHash: '',
    email: '',
    role:'',
  };

  errorMessage = '';
  message = '';

  constructor(
    private userApiService: UserApiService,
    private router: Router,
    private activeRoute: ActivatedRoute
  ) {
    localStorage.removeItem('user');
    localStorage.removeItem('myToken');
    this.activeRoute.params.subscribe((params) => {
      this.errorMessage = params['error'];
      this.message = params['success'];
    });
  }

  userLogin(loginForm: NgForm) {
    console.log('User login called');
    this.userApiService.getUser(this.user).subscribe({
      next: (data: any) => {
        this.user = data;
        localStorage.setItem('user', JSON.stringify(this.user));
        localStorage.setItem('myToken', this.user.token!);
        console.log('Data:', this.user);
       
          this.router.navigateByUrl('/home');       
        
      },
      error: (error) => {
        console.log(error);
        this.errorMessage = error?.error;
        loginForm.reset();
      },
    });
  }

  Cancel(loginForm: NgForm) {
    console.log('cancel called');
    loginForm.reset();
    this.message = '';
    this.errorMessage = '';
  }


}
