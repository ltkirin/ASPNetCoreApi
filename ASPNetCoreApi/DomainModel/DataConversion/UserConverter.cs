using DataTransition.DTO;
using DomainModel.DataConversion.common;
using DomainModel.Entity.user;

namespace DomainModel.DataConversion
{
    class UserConverter : BaseEntityConverter<User, UserDTO>
    {
        private TeamConverter teamConverter;

        public UserConverter(TeamConverter teamConverter)
        {
            this.teamConverter = teamConverter;
        }

        public override UserDTO GetDTO(User entity)
        {
            UserDTO dto = new UserDTO();
            dto.Id = entity.Id;
            dto.Login = entity.Login;
            dto.PasswordHash = entity.PasswordHash;
            if(string.IsNullOrEmpty(entity.Callsign))
            {
                dto.Callsign = entity.Callsign;
            }
            if(entity.Team != null)
            {
                dto.Team = teamConverter.GetDTO(entity.Team);
            }
            return dto;
        }

        public override User GetEntity(UserDTO dto)
        {
            User entity = new User();
            entity.Id = dto.Id;
            entity.Login = dto.Login;
            entity.PasswordHash = dto.PasswordHash;
            if (string.IsNullOrEmpty(dto.Callsign))
            {
               entity.Callsign = dto.Callsign;
            }
            if (dto.Team != null)
            {
                entity.Team = teamConverter.GetEntity(dto.Team);
            }
            return entity;
        }
    }
}
