using ASPNetCoreApi.Models.common;

namespace ASPNetCoreApi.Models
{
    public class UserModel : BaseModel
    {
        private string login;
        private string passwordHash;
        private string callsign;
        private TeamModel team;

        public UserModel(string login, string passwordHash) : base()
        {
            this.login = login;
            this.passwordHash = passwordHash;
        }

        public UserModel(int id, string login, string passwordHash) : base(id)
        {
            this.login = login;
            this.passwordHash = passwordHash;
        }

        public string PasswordHash
        {
            get => passwordHash;
            set => passwordHash = value;
        }
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string Callsign
        {
            get => callsign;
            set => callsign = value;
        }
        public TeamModel Team
        {
            get => team;
            set => team = value;
        }
    }
}