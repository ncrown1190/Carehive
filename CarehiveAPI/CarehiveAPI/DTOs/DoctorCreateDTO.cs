namespace CarehiveAPI.DTOs
{
    public class DoctorCreateDTO
    {
        public int UserId { get; set; }
        public string? DoctorName { get; set; }

        public string? Specialty { get; set; }
    }
}
