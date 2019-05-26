using ASPNetCoreApi.DataConversion.common;
using ASPNetCoreApi.Models;
using DataTransition.DTO;
using System;

namespace ASPNetCoreApi.DataConversion
{
    class TeamsConverter : BaseModelConverter<TeamModel, TeamDTO>
    {
        public override TeamDTO GetDTO(TeamModel model)
        {
            TeamDTO dto = new TeamDTO();
            dto.Id = model.Id;
            dto.Title = model.Title;
            return dto;
        }

        public override TeamModel GetModel(TeamDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Title))
            {
                throw new Exception("Unable to create TeamModel with empty title!");
            }
            if (dto.Id != 0)
            {
                return new TeamModel(dto.Id,dto.Title);
            }
            else
            {
                return new TeamModel(dto.Title);
            }

        }
    }
}
