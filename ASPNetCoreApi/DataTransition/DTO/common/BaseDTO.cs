using Newtonsoft.Json;

namespace DataTransition.common.DTO
{
    /// <summary>
    /// Base Data transition object for Entity classes
    /// </summary>
    public abstract class BaseDTO
    {
        /// <summary>
        /// Object database ID
        /// </summary>
        protected int id;

        [JsonProperty]
        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}
