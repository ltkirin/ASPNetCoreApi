using ASPNetCoreApi.DataConversion.common;
using ASPNetCoreApi.Models;
using ASPNetCoreApi.Models.Factory;
using DataTransition.DTO;
using System;
using System.Collections.Generic;

namespace ASPNetCoreApi.DataConversion
{
    class UserConverter : BaseModelConverter<UserModel, UserDTO>
    {
        private TeamsConverter teamConverter;

        public UserConverter(TeamsConverter teamConverter)
        {
            this.teamConverter = teamConverter;
        }

        public override UserDTO GetDTO(UserModel model)
        {
            UserDTO dto = new UserDTO();
            dto.Id = model.Id;
            dto.Login = model.Login;
            dto.PasswordHash = model.PasswordHash;
            if(!string.IsNullOrEmpty(model.Callsign))
            {
                dto.Callsign = model.Callsign;
            }
            if(model.Team != null)
            {
                dto.Team = teamConverter.GetDTO(model.Team);
            }
            return dto;
        }

        public override UserModel GetModel(UserDTO dto)
        {
            UserModel model;
            if(string.IsNullOrEmpty(dto.PasswordHash) || string.IsNullOrEmpty(dto.Login))
            {
                throw new Exception("Invalid DTO!");
            }
            string[] props = new string[] { dto.Login, dto.PasswordHash };
            model = (dto.Id != 0)
                ? ModelFactory.Instance.GetUserModel(dto.Id, props)
                : ModelFactory.Instance.GetUserModel(props);
            if(!string.IsNullOrEmpty(dto.Callsign))
            {
                model.Callsign = dto.Callsign;
            }
            if(dto.Team != null)
            {
                model.Team = teamConverter.GetModel(dto.Team);
            }
            return model;
        }
    }
}
