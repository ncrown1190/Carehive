namespace CarehiveAPI.DTOs
{
    public class ScheduleCreateDTO
    {
        public int ScheduleId { get; set; }

        public string? DoctorName { get; set; } = null;

        public DateOnly ScheduleDate { get; set; }

        public TimeOnly AvailableFrom { get; set; }

        public TimeOnly AvailableTo { get; set; }
    }
}
