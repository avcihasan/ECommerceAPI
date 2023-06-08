using ECommerceAPI.Application.DTOs.UserDTOs;

namespace ECommerceAPI.Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryResponse
    {
        public List<UserDto> Users { get; set; }
        public int TotalUsersCount { get; set; }
    }
}