﻿namespace CarehiveAPI.DTOs
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        public DateOnly ScheduleDate { get; set; }

        public TimeOnly AvailableFrom { get; set; }

        public TimeOnly AvailableTo { get; set; }

        public string? DoctorName { get; set; } = null!;
    }
}
