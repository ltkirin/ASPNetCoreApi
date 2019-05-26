using ASPNetCoreApi.Models.Factory.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASPNetCoreApi.Models.Factory
{
    /// <summary>
    /// Singletone Models factory
    /// </summary>
    public class ModelFactory
    {
        private static ModelFactory instance;

        

        private IModelFactory<TeamModel> teamFactory = new TeamFactory();
        private IModelFactory<UserModel> userFactory = new UserFactory();
        /// <summary>
        /// Actual instance of Factory
        /// </summary>
        public static ModelFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModelFactory();
                }
                return instance;
            }
        }

        public TeamModel GetTeamModel(int id, IList<string> props)
        {
            return teamFactory.Get(id, props);
        }

        public TeamModel GetTeamModel(IList<string> props)
        {
            return teamFactory.Get(props);
        }

        public UserModel GetUserModel(int id, IList<string> props)
        {
            return userFactory.Get(id, props);
        }

        public UserModel GetUserModel(IList<string> props)
        {
            return userFactory.Get(props);
        }
    }
}
