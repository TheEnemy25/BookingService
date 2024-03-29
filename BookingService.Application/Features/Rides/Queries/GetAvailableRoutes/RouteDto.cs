﻿namespace BookingService.Application.Features.Rides.Queries.GeAvailableRoutes
{
    public class RouteDto
    {
        public string RouteId { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
        public int SeatsAvailable { get; set; }
        public string ExtraInfo { get; set; } = string.Empty;
    }
}