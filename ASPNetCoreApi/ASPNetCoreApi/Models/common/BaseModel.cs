using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreApi.Models.common
{
    /// <summary>
    /// Base model objet, containing ID property
    /// </summary>
    public abstract class BaseModel
    {
        protected int id;

        /// <summary>
        /// Create new Base Model based object with known Id and properties
        /// </summary>
        /// <param name="id">Databadse ID value</param>
        /// <param name="props">Properties collection</param>
        public BaseModel(int id)
        {
            this.id = id;
        }
        /// <summary>
        /// Create new Base Model based object with properties, but with no Id 
        /// </summary>
        /// <param name="props">Properties collection</param>
        public BaseModel()
        {
            id = 0;
        }

        /// <summary>
        /// Id of the Model in the database. 
        /// If value = 0, model is not registred in the base yet.
        /// </summary>
        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}
