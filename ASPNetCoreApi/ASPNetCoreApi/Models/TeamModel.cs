using ASPNetCoreApi.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreApi.Models
{
    /// <summary>
    /// Model object for Team
    /// </summary>
    public class TeamModel : BaseModel
    {
        private string title;

        public TeamModel() : base()
        {
        }

        /// <summary>
        /// Create new Team model with no Id value
        /// </summary>
        /// <param name="props">Strings collection for team properties</param>
        public TeamModel(string title) : base()
        {
            this.title = title;
        }

        /// <summary>
        /// Create new Team model from database, or with otherwise known id
        /// </summary>
        /// <param name="id">Team databse ID</param>
        /// <param name="title">Team title</param>
        public TeamModel(int id, string title) : base(id)
        {
            this.title = title;
        }

        /// <summary>
        /// Team database Id. If value = 0, team is loaded not from the database and can be absen there
        /// </summary>
        /// <summary>
        /// Team title
        /// </summary>
        public string Title
        {
            get => title;
            set => title = value;
        }

        /// <summary>
        /// Check if sent Properties lis contains Title value and get it
        /// </summary>
        /// <param name="props"></param>
        /// <returns></returns>
        private string SetTitle(IList<string> props)
        {
            string newTeamTitle = props[0];
            if (string.IsNullOrEmpty(newTeamTitle))
            {
                throw new Exception("User attempted to add a Team with empty name!");
            }
            return newTeamTitle;
        }
    }
}
