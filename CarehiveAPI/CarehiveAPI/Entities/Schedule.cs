using System;
using System.Collections.Generic;

namespace CarehiveAPI.Entities;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;
}
