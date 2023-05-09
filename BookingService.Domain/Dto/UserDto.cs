﻿using BookingService.Domain.Dto;


namespace BookingService.Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public List<RideDto> Rides { get; set; }
    }
}
