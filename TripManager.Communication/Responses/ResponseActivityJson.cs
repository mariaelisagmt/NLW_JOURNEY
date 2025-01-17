﻿using TripManager.Communication.Enums;

namespace TripManager.Communication.Responses;

public class ResponseActivityJson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public ActivityStatus Status { get; set; }
}
