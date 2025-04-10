namespace CarehiveAPI.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }

        public string? DoctorName { get; set; }

        public int DoctorId { get; set; }

        public DateOnly? AppointmentDate { get; set; }

        public TimeOnly? AppointmentTime { get; set; }

        public string? Status { get; set; }

    }
}
