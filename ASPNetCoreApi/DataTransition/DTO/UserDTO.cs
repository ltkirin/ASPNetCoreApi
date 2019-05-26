using DataTransition.common.DTO;
using Newtonsoft.Json;

namespace DataTransition.DTO
{
    [JsonObject]
    public class UserDTO : BaseDTO
    {
        private string passwordHash;
        private string login;
        private string callsign;
        private TeamDTO team;

        [JsonProperty]
        public string PasswordHash
        {
            get => passwordHash;
            set => passwordHash = value;
        }
        [JsonProperty]
        public string Login
        {
            get => login;
            set => login = value;
        }
        [JsonProperty]
        public string Callsign
        {
            get => callsign;
            set => callsign = value;
        }
        [JsonProperty]
        public TeamDTO Team
        {
            get => team;
            set => team = value;
        }
    }
}
