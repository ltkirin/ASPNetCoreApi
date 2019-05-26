using DataTransition.DTO;
using DataTransition.Interfaces;
using DomainModel.DAO.enums;
using DomainModel.DataConversion;
using DomainModel.DbModel;
using DomainModel.Entity.team;
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
                    foreach (User user in foundEntities)
                    {
                        result.Add(DataConverter.Instance.GetDTO(user) as UserDTO);
                    }

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

        public int Update(UserDTO dtoToIUpdate)
        {
            if (dtoToIUpdate.Id == 0)
            {
                return (int)SaveStatusCode.EntityToUpdateNotFound;
            }
            IList<User> searchResult;
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                searchResult = context.Users.Where(t => t.Id == dtoToIUpdate.Id).ToList();

                if (!searchResult.Any())
                {
                    return (int)SaveStatusCode.EntityToUpdateNotFound;
                }
                if (searchResult.Count > 1)
                {
                    return (int)SaveStatusCode.MultipleEntitiesToUpdateFound;
                }
                searchResult[0].Callsign = dtoToIUpdate.Callsign;
                if (dtoToIUpdate.Team != null)
                {
                    searchResult[0].Team = DataConverter.Instance.GetEntity(dtoToIUpdate.Team) as Team;
                }
                searchResult[0].Login = dtoToIUpdate.Login;
                context.SaveChanges();
                return (int)SaveStatusCode.SaveOK;
            }
        }
    }
}

