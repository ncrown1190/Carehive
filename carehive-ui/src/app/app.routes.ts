import { Routes } from '@angular/router';
import { DoctorSearchComponent } from './doctor-search/doctor-search.component';
import { DoctorDashboardComponent } from './DashBoard/Doctor/doctor-dashboard/doctor-dashboard.component';
import { DoctorAppointListComponent } from './DashBoard/Doctor/doctor-appoint-list/doctor-appoint-list.component';
import { DoctorListComponent } from './DashBoard/Doctor/doctor-list/doctor-list.component';
import { PatientDashboardComponent } from './DashBoard/Patients/patient-dashboard/patient-dashboard.component';
import { PatientAppointmentComponent } from './DashBoard/Patients/patient-appointment/patient-appointment.component';
import { AppointmentFormComponent } from './DashBoard/Patients/appointment-form/appointment-form.component';
import { MedicalHistoryComponent } from './DashBoard/Patients/medical-history/medical-history.component';
import { NotificationsComponent } from './DashBoard/Patients/notifications/notifications.component';
import { DoctorsIdComponent } from './DashBoard/Patients/doctors-id/doctors-id.component';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path:'doctorSearch', component: DoctorSearchComponent},
    {path: 'availableDoctor', component: DoctorsIdComponent},
    {path: 'patientDashboard', component: PatientDashboardComponent,
        children: [
            {
                path: 'patientappointment', component: PatientAppointmentComponent
            },
            {
                path: 'patientForm', component: AppointmentFormComponent
            },
            
            {
                path: 'medical-history', component: MedicalHistoryComponent
            },
            {
                path: 'notifications', component: NotificationsComponent
            },
        ]
     },
    {path: 'doctorDashboard', component: DoctorDashboardComponent,
        children: [
            {
                path: 'doctor-appointment', component: DoctorAppointListComponent
            },
            {
                path: 'doctors-list', component: DoctorListComponent
            },
        ]
     }
];
