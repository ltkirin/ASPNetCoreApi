using DataTransition.DTO;
using DataTransition.Interfaces;
using DomainModel.DAO.enums;
using DomainModel.DataConversion;
using DomainModel.DbModel;
using DomainModel.Entity.common;
using DomainModel.Entity.user;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.DAO
{
    public class UserDAO : IDAO<UserDTO>
    {
        public IList<UserDTO> Find(UserDTO searchParameters)
        {
            List<UserDTO> result = new List<UserDTO>();
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                IList<User> foundEntities = new List<User>();
                if (searchParameters.Id != 0)
                {
                    foundEntities = context.Users
                        .Where(u => u.Id == searchParameters.Id).ToList();

                }
                else
                {
                    if (searchParameters.Team != null)
                    {
                        foundEntities = context.Users
                           .Where(t => t.Team.Id == searchParameters.Team.Id)
                           .ToList();
                    }
                    else if (!string.IsNullOrEmpty(searchParameters.Callsign))
                    {
                        foundEntities = context.Users
                           .Where(t => t.Callsign == searchParameters.Callsign)
                           .ToList();
                    }
                    else if (!string.IsNullOrEmpty(searchParameters.Login))
                    {
                        foundEntities = context.Users
                           .Where(t => t.Login == searchParameters.Login)
                           .ToList();
                    }
                }

                if (foundEntities.Any())
                {
                    
                    result.AddRange(DataConverter.Instance.GetDTO(foundEntities as IList<EntityBase>) as IList<UserDTO>);
                }
            }

            return result;
        }

        public int Save(UserDTO dtoToSave)
        {
            User userToSave = DataConverter.Instance.GetEntity(dtoToSave) as User;
            //TODO: Ask if the Context is better to initialize with the DAO intialization, or create a new one each time
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                if (!context.Users.Where(u => u.Login == userToSave.Login).Any())
                {
                    context.Users.Add(userToSave);
                    context.SaveChanges();
                    return (int)SaveStatusCode.SaveOK;
                }
                else
                {
                    return (int)SaveStatusCode.NameAllreadyTaken;
                }
            }

        }
    }
}
