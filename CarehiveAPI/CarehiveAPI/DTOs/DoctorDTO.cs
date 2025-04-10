using CarehiveAPI.Entities;

namespace CarehiveAPI.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }
        public string? Phone { get; set; }

        public string? Specialty { get; set; }

        public string? UserName { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
