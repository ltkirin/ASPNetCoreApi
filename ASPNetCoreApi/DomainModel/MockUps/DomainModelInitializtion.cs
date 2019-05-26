using DataTransition.DataManagement;
using DataTransition.Service;
using DomainModel.DAO;
using DomainModel.Service.authorization;

namespace DomainModel.MockUps
{
    /// <summary>
    /// Static util for initializing DAOs in Data Transition Data Manager. Will be removed after IoC integration
    /// </summary>
    public static class DomainModelInitializtion
    {
        public static void Initialize()
        {
            DataManager.Instance.TeamDAO = new TeamDAO();
            DataManager.Instance.UserDAO = new UserDAO();
            AuthorizationService.Instance.UserContext = new UserContext();
        }
    }
}
