using DataTransition.DTO;
using DataTransition.Service.interfaces;
using DomainModel.DbModel;
using System.Linq;

namespace DomainModel.Service.authorization
{
    public class UserContext : IUserContext
    {
        public bool Authorised(UserDTO user)
        {
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                return context.Users
                    .Where(u => u.Login == user.Login 
                    && user.PasswordHash.Contains(u.PasswordHash))
                    .Any();
            }
        }
    }
}
