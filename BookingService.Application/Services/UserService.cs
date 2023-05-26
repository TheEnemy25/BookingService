using AutoMapper;
using BookingService.Application.Services.Interfaces;
using BookingService.Domain.Dto;
using BookingService.Domain.Entities;
using BookingService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Application.Services
{

    public class UserService : IUserService
    {
        private readonly List<UserDto> _users;

        public UserService()
        {
            _users = new List<UserDto>();
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            // Генерація унікального ідентифікатора для нового користувача
            int newUserId = _users.Count + 1;
            userDto.Id = newUserId;

            // Додавання нового користувача до списку
            _users.Add(userDto);

            // Повернення створеного користувача
            return userDto;
        }

        public async Task UpdateUser(UserDto userDto)
        {
            // Знаходження користувача за ідентифікатором
            UserDto existingUser = _users.FirstOrDefault(u => u.Id == userDto.Id);
            if (existingUser == null)
            {
                throw new ArgumentException($"User with ID {userDto.Id} does not exist.");
            }

            // Оновлення властивостей користувача
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Rides = userDto.Rides;
        }

        public async Task DeleteUser(int userId)
        {
            // Знаходження користувача за ідентифікатором
            UserDto existingUser = _users.FirstOrDefault(u => u.Id == userId);
            if (existingUser == null)
            {
                throw new ArgumentException($"User with ID {userId} does not exist.");
            }

            // Видалення користувача зі списку
            _users.Remove(existingUser);
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            // Знаходження користувача за ідентифікатором
            UserDto user = _users.FirstOrDefault(u => u.Id == userId);
            return user;
        }

        public async Task<ICollection<RideDto>> GetUserRides(int userId)
        {
            // Отримання поїздок користувача за ідентифікатором
            // Логіка отримання поїздок може бути додана тут
            // Повернення списку поїздок
            return new List<RideDto>();
        }
    }
}