namespace CarehiveAPI.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public string? PatientFullName { get; set; }

        public string? DoctorName { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string? Status { get; set; }

    }
}
