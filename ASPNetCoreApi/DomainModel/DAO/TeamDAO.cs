using DataTransition.DTO;
using DataTransition.Interfaces;
using DomainModel.DAO.enums;
using DomainModel.DataConversion;
using DomainModel.DbModel;
using DomainModel.Entity.team;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.DAO
{
    /// <summary>
    /// Data access object for Team DTOs
    /// </summary>
    public class TeamDAO : IDAO<TeamDTO>
    {
        public TeamDAO()
        {
        }

        /// <summary>
        /// Find Team by given paramataers
        /// </summary>
        /// <param name="searchParameeters">DTO with given parameeters</param>
        /// <returns>Collection of found </returns>
        public IList<TeamDTO> Find(TeamDTO searchParameeters)
        {
            List<TeamDTO> result = new List<TeamDTO>();
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                Team foundEntity;
                if (searchParameeters.Id != 0)
                {
                    foundEntity = context.Teams
                        .Where(t => t.Id == searchParameeters.Id)
                        .FirstOrDefault();

                }
                else
                {
                    foundEntity = context.Teams
                       .Where(t => t.Title == searchParameeters.Title)
                       .FirstOrDefault();
                }

                if (foundEntity != null)
                {
                    result.Add(DataConverter.Instance.GetDTO(foundEntity) as TeamDTO);
                }
            }

            return result;
        }
        /// <summary>
        /// Try to save a new Entity to Database and get operation result code
        /// </summary>
        /// <param name="dtoToSave">Object to save</param>
        /// <returns>Operation result code</returns>
        public int Save(TeamDTO dtoToSave)
        {
            Team teamToSave = DataConverter.Instance.GetEntity(dtoToSave) as Team;
            //TODO: Ask if the Context is better to initialize with the DAO intialization, or create a new one each time
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                if (!context.Teams.Where(t => t.Title == teamToSave.Title).Any())
                {
                    context.Teams.Add(teamToSave);
                    context.SaveChanges();
                    return (int)SaveStatusCode.SaveOK;
                }
                else
                {
                    return (int)SaveStatusCode.NameAllreadyTaken;
                }
            }

        }

        public int Update(TeamDTO dtoToIUpdate)
        {
            if (dtoToIUpdate.Id == 0)
            {
                return (int)SaveStatusCode.EntityToUpdateNotFound;
            }
            IList<Team> searchResult;
            using (AirsoftBaseContext context = new AirsoftBaseContext())
            {
                searchResult = context.Teams.Where(t => t.Id == dtoToIUpdate.Id).ToList();

                if (!searchResult.Any())
                {
                    return (int)SaveStatusCode.EntityToUpdateNotFound;
                }
                if (searchResult.Count > 1)
                {
                    return (int)SaveStatusCode.MultipleEntitiesToUpdateFound;
                }
                searchResult[0].Title = dtoToIUpdate.Title;
                context.SaveChanges();
                return (int)SaveStatusCode.SaveOK;
            }
        }
    }
}
