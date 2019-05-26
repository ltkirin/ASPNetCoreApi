using DataTransition.common.DTO;
using Newtonsoft.Json;

namespace DataTransition.DTO
{
    /// <summary>
    /// Team data transition object
    /// </summary>
    [JsonObject]
    public class TeamDTO : BaseDTO
    {
        private string title;

        /// <summary>
        /// Team title
        /// </summary>
        [JsonProperty]
        public string Title
        {
            get => title;
            set => title = value;
        }
    }
}
