using Ardalis.Specification;
using BookingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookingService.Domain.Specifications
{
    public class GetUserByEmailAndPassword : Specification<User>
    {
        public GetUserByEmailAndPassword(string email, string password)
        {
            Query.Where(t => t.Email == email && t.Password == password);
        }
    }
}
