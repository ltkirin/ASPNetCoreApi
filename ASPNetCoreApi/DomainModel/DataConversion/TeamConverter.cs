using DataTransition.DTO;
using DomainModel.DataConversion.common;
using DomainModel.Entity.team;

namespace DomainModel.DataConversion
{
    /// <summary>
    /// Entity-DTo converter for Team objects
    /// </summary>
    class TeamConverter : BaseEntityConverter<Team, TeamDTO>
    {
        /// <summary>
        /// Get Team DTO from Team Entity
        /// </summary>
        /// <param name="entity">Team Entity</param>
        /// <returns>Converted DTO</returns>
        public override TeamDTO GetDTO(Team entity)
        {
            TeamDTO dto = new TeamDTO();
            dto.Id = entity.Id;
            dto.Title = entity.Title;
            return dto;
        }
        /// <summary>
        /// Convert Team DTO to Team Entity
        /// </summary>
        /// <param name="dto">Team DTO</param>
        /// <returns>Converted Entity</returns>
        public override Team GetEntity(TeamDTO dto)
        {
            Team entity = new Team();
            entity.Id = dto.Id;
            entity.Title = dto.Title;
            return entity;
        }
    }
}
