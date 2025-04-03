namespace CarehiveAPI.DTOs
{
    public class AppointmentCreateDTO
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string? Status { get; set; } = "Pending"; //Default value
    }
}
