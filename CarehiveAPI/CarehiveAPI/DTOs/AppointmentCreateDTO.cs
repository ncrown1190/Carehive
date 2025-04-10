namespace CarehiveAPI.DTOs
{
    public class AppointmentCreateDTO
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateOnly? AppointmentDate { get; set; }
        public TimeOnly? AppointmentTime { get; set; }

        public string? Status { get; set; } = "Pending"; //Default value
    }
}
