using CRUDCsharp.Dtos;

namespace CRUDCsharp.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> Get();
        Task<UserDto> GetById(int id);
        Task<UserDto>Add(UserInsertDto insertDto);
       Task<UserDto>Update(int id, UserUpdateDto updateDto);

        Task<UserDto>Delete(int id);
    }
}
