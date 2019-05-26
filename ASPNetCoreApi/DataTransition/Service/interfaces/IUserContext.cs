using DataTransition.DTO;

namespace DataTransition.Service.interfaces
{
    public interface IUserContext
    {
        bool Authorised(UserDTO user);

    }
}
