using OnionArchitecture.Domain.DTO;
namespace OnionArchitecture.Data.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAll();
        Task<UserResponseDto> GetById(int id);
        Task<UserResponseDto> Add(UserRequestDto userRequestDto);
        Task<UserResponseDto> Update(UserRequestUpdateDto userRequestUpdateDto);

        Task<bool> Delete(int id);
    }
}
