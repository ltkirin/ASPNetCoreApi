

namespace DomainModel.Entity.common
{
    /// <summary>
    /// Basic class for all of Entity classes, containing Id for database tables
    /// </summary>
    public abstract class EntityBase
    {
        protected int id;
        /// <summary>
        /// Databse Id for entity
        /// </summary>
        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}
