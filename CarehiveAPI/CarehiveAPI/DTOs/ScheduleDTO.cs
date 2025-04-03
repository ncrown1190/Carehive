namespace CarehiveAPI.DTOs
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public string? PatientFullName { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
