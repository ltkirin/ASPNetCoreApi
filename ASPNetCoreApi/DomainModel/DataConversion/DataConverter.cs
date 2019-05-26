using DataTransition.common.DTO;
using DataTransition.DTO;
using DomainModel.Entity.common;
using DomainModel.Entity.team;
using DomainModel.Entity.user;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.DataConversion
{
    public class DataConverter
    {

        private static DataConverter instance;

        private TeamConverter teamConverter;
        private UserConverter userConverter;

        public DataConverter()
        {
            teamConverter = new TeamConverter();
            userConverter = new UserConverter(teamConverter);
        }

        public static DataConverter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataConverter();
                }
                return instance;
            }
        }

        public EntityBase GetEntity(BaseDTO dto)
        {
            if (dto is TeamDTO)
            {
                return teamConverter.GetEntity(dto as TeamDTO);
            }
            if (dto is UserDTO)
            {
                return userConverter.GetEntity(dto as UserDTO);
            }
            throw new Exception($"No converter for {dto} object!");
        }

        public IList<EntityBase> GetEntity(IList<BaseDTO> dtos)
        {
            if (dtos is IList<TeamDTO>)
            {
                if (dtos.Any())
                {
                    return teamConverter.GetEntity(dtos as IList<TeamDTO>) as IList<EntityBase>;
                }
                return new List<Team>() as IList<EntityBase>;
            }
            if (dtos is IList<UserDTO>)
            {
                if (dtos.Any())
                {
                    return userConverter.GetEntity(dtos as IList<UserDTO>) as IList<EntityBase>;
                }
                return new List<User>() as IList<EntityBase>;
            }
            throw new Exception($"No converter for {dtos[0]} object!");

        }

        public BaseDTO GetDTO(EntityBase entity)
        {
            if (entity is Team)
            {
                return teamConverter.GetDTO(entity as Team);
            }
            if (entity is User)
            {
                return userConverter.GetDTO(entity as User);
            }
            throw new Exception($"No converter for {entity} object!");
        }

        public IList<BaseDTO> GetDTO(IList<EntityBase> entities)
        {
            if (entities is IList<Team>)
            {
                if (entities.Any())
                {
                    return teamConverter.GetDTO(entities as IList<Team>) as IList<BaseDTO>;
                }
                return new List<TeamDTO>() as IList<BaseDTO>;
            }
            if (entities is IList<User>)
            {
                if (entities.Any())
                {
                    return userConverter.GetDTO(entities as IList<User>) as IList<BaseDTO>;
                }
                return new List<UserDTO>() as IList<BaseDTO>;
            }
            throw new Exception($"No converter for {entities[0]} object!");
        }
    }
}
