namespace CarehiveAPI.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public string FullName { get; set; } = null!;

        public string Specialty { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? AvailabilityStatus { get; set; }

    }
}
