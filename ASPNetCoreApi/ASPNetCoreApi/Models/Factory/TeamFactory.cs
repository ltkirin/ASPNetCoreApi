using ASPNetCoreApi.Models.Factory.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreApi.Models.Factory
{
    public class TeamFactory : IModelFactory<TeamModel>
    {
        /// <summary>
        /// Create a new Team model with mo Id value
        /// </summary>
        /// <param name="teamTitle">Team title</param>
        /// <returns>Team model with default id value</returns>
        public TeamModel Get(IList<string> props)
        {
            if (props.Any())
            {
                string title = props[0];
                return new TeamModel(title);
            }
            else throw new Exception("Unable to create Team model without Properties!");
        }
        /// <summary>
        /// Create new Team model with known Id value
        /// </summary>
        /// <param name="id">Model database Id</param>
        /// <param name="teamTitle">Team title</param>
        /// <returns>Team model with set id value</returns>
        public TeamModel Get(int id, IList<string> props)
        {
            string title;
            if (props.Any())
            {
                title = props[0];
            }
            else throw new Exception("Unable to create Team model without Properties!");
            //Check in case 0 id was sent to the method
            if (id > 0)
            {
                return new TeamModel(id, title);
            }
            return Get(props);
        }
    }
}
