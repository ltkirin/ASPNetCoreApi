using DomainModel.Entity.common;

namespace DomainModel.Entity.team
{
    /// <summary>
    /// Entity class for Airsoft team
    /// </summary>
    public class Team : EntityBase
    {

        private string title;

        /// <summary>
        /// Title of the Team
        /// </summary>
        public string Title
        {
            get => title;
            set => title = value;
        }
    }
}
