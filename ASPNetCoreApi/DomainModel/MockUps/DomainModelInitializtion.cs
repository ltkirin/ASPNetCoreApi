using DataTransition.DataManagement;
using DomainModel.DAO;

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
        }
    }
}
