using CSharpFunctionalExtensions;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;

namespace ValconLibrary.Service.Users
{
    public interface IUserService
    {
        Task<Result<UserDTO, IEnumerable<string>>> Create(User user);
        List<UserDTO> GetAll(string role);
        Task<Result<UserDTO, IEnumerable<string>>> UpdateUserProfileAsync(Guid userId,User user);
        Task<Result<UserDTO, IEnumerable<string>>> UpdateUserPasswordAsync(Guid userId,User user);
    }
}
