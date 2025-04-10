using System;
using System.Collections.Generic;

namespace CarehiveAPI.Entities;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly ScheduleDate { get; set; }

    public TimeOnly AvailableFrom { get; set; }

    public TimeOnly AvailableTo { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;
}
