using System;

public class RouteDto
{
    public int Id { get; set; }
    public string RouteId { get; set; }
    public DateTime DepartureTime{ get; set; }
    public DateTime ArrivalTime{ get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string ExtraInfo { get; set; }
}
