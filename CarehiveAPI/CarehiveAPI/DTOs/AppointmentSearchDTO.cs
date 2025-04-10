using CarehiveAPI.Entities;

namespace CarehiveAPI.DTOs
{
    public class AppointmentSearchDTO
    {
        public int AppointmentId { get; set; }
        public string? DoctorName { get; set; }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }

        public int DoctorId { get; set; }

        public DateOnly? AppointmentDate { get; set; }

        public TimeOnly? AppointmentTime { get; set; }

        public string? Status { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual User Patient { get; set; } = null!;
    }
}
