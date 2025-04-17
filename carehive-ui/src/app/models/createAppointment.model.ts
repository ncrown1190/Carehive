export interface CreateAppointment{
    patientId: number;
    patientName: string;
    doctorId: number;
    doctorName: string;
    appointmentDate: string;
    appointmentTime: string;
    status: string;
}
