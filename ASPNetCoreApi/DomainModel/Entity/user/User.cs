using DomainModel.Entity.common;
using DomainModel.Entity.team;

namespace DomainModel.Entity.user
{
    /// <summary>
    /// Entity class, for User 
    /// </summary>
    public class User : EntityBase
    {

        #region Fields
        private string passwordHash;
        private string login;
        private string callsign;
        private Team team;
        #endregion

        #region Properties
        /// <summary>
        /// User's password hash
        /// </summary>
        public string PasswordHash
        {
            get => passwordHash;
            set => passwordHash = value;
        }
        /// <summary>
        /// Login, used to authorize into a sysetem
        /// </summary>
        public string Login
        {
            get => login;
            set => login = value;
        }
        /// <summary>
        /// User's airsoft callsign
        /// </summary>
        public string Callsign
        {
            get => callsign;
            set => callsign = value;
        }
        /// <summary>
        /// Team, that includes current User
        /// </summary>
        public Team Team
        {
            get => team;
            set => team = value;
        }
        #endregion
    }
}
