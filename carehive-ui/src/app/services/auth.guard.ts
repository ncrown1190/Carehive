import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";


export const authGuard: CanActivateFn = (route, state) => {
    console.log('Auth guard called');
    var router = inject(Router);
  
    //Check the token, it is used to protect route against unauthorized access
    var token = localStorage.getItem('myToken');
    console.log('Token in AuthGuard:', token);

    if (token && token != '') {
      return true;
    }
  
    //User not logged in, re route to login page.
    router.navigateByUrl('/login');
  
    return false;
  };