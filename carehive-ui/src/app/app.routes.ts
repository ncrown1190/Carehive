import { Routes } from '@angular/router';
import { LoginComponent } from './user/login/login.component';
import { authGuard } from './services/auth.guard';
import { HomeComponent } from './DashBoard/home/home.component';
import { PatientDashboardComponent } from './DashBoard/Patients/patient-dashboard/patient-dashboard.component';
import { PatientAppointmentComponent } from './DashBoard/Patients/patient-appointment/patient-appointment.component';
import { AppointmentFormComponent } from './DashBoard/Patients/appointment-form/appointment-form.component';
import { DoctorsIdComponent } from './DashBoard/Patients/doctors-id/doctors-id.component';
import { MedicalHistoryComponent } from './DashBoard/Patients/medical-history/medical-history.component';
import { NotificationsComponent } from './DashBoard/Patients/notifications/notifications.component';
import { DoctorDashboardComponent } from './DashBoard/Doctor/doctor-dashboard/doctor-dashboard.component';
import { DoctorAppointListComponent } from './DashBoard/Doctor/doctor-appoint-list/doctor-appoint-list.component';
import { AdminDashboardComponent } from './DashBoard/Admin/admin-dashboard/admin-dashboard.component';
import { AddDoctorsComponent } from './DashBoard/Admin/add-doctors/add-doctors.component';
import { DoctorScheduleComponent } from './doctor-schedule/doctor-schedule.component';
import { SignupComponent } from './user/signup/signup.component';
import { DoctorSearchComponent } from './doctor-search/doctor-search.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'home', component: HomeComponent },  
  {
    path: 'patientDashboard',
    component: PatientDashboardComponent,
    children: [
      {
        path: 'patientappointment',
        component: PatientAppointmentComponent,
      },
      {
        path: 'patientForm',
        component: AppointmentFormComponent,
      },
      {
        path: 'availableDoctor',
        component: DoctorsIdComponent,
      },

      {
        path: 'medical-history',
        component: MedicalHistoryComponent,
      },
      {
        path: 'notifications',
        component: NotificationsComponent,
      },
      {
        path: 'schedule',
        component: DoctorScheduleComponent,
      },
    ],
  },
  {
    path: 'doctorDashboard',
    component: DoctorDashboardComponent,
    children: [
      {
        path: 'doctor-appointment',
        component: DoctorAppointListComponent,
      },
      {
        path: 'medical-history',
        component: MedicalHistoryComponent,
      },
      {
        path: 'notifications',
        component: NotificationsComponent,
      },
      {
        path: 'schedule',
        component: DoctorScheduleComponent,
      },
      {
        path: 'external', 
        component: DoctorSearchComponent
      },
    ],
  },
  //{ path: 'patientDashboard', component: PatientDashboardComponent },
  {
    path: 'adminDashboard',
    component: AdminDashboardComponent,
    children: [
      {
        path: 'addDoctors',
        component: AddDoctorsComponent,
      },
      {
        path: 'schedule',
        component: DoctorScheduleComponent,
      },
      {
        path: 'patientForm',
        component: AppointmentFormComponent,
      },
      {
        path: 'notifications',
        component: NotificationsComponent,
      },
      {
        path: 'external', 
        component: DoctorSearchComponent
      },
      // {
      //     path: 'doctors-list', component: DoctorListComponent
      // },
    ],
  },
];
