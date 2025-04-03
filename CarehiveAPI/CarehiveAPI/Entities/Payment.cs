﻿using System;
using System.Collections.Generic;

namespace CarehiveAPI.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int AppointmentId { get; set; }

    public decimal Amount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
}
