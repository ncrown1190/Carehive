export interface CreateAppointment{
    patientId: number;
    doctorId: number;
    appointmentDate: string;
    appointmentTime: string;
    status: string;
}
