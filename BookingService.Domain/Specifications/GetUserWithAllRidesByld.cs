using Ardalis.Specification;
using BookingService.Domain.Entities;

namespace BookingService.Domain.Specifications
{
    public class GetUserWithAllRidesById : Specification<User>
    {
        public GetUserWithAllRidesById(int userId)
        {
            Query.Where(u => u.UserId == userId).Include(u => u.Routes);
        }
    }
}