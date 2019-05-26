using DomainModel.Entity.common;
using DomainModel.Entity.user;

namespace DomainModel.Entity.weapon
{
    /// <summary>
    /// Entity class for Airsoft weapons 
    /// </summary>
    public class Weapon : EntityBase
    {
        #region Fields
        private string name;
        private int ballVelocity;
        private User owner;
        #endregion

        #region Properties
        /// <summary>
        /// Airsoft gun name
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Ball velocity f the Airsoft gun
        /// </summary>
        public int BallVelocity
        {
            get => ballVelocity;
            set => ballVelocity = value;
        }
        /// <summary>
        /// Owner of the Airsoft gun
        /// </summary>
        public User Owner
        {
            get => owner;
            set => owner = value;
        }
        #endregion
    }
}
