using DataTransition.common.DTO;
using System.Collections.Generic;

namespace DataTransition.Interfaces
{
    /// <summary>
    /// Data access Object interface
    /// </summary>
    /// <typeparam name="T">Type of the DTO to be processed</typeparam>
    public interface IDAO<T> 
        where T: BaseDTO
    {
        /// <summary>
        /// Try to save Object and get the result response code
        /// </summary>
        /// <param name="dtoToSave">Object to save</param>
        /// <returns>Save operation response code</returns>
        int Save(T dtoToSave);
        /// <summary>
        /// Find objects by search parameters
        /// </summary>
        /// <param name="searchParameeters">DTO with search parmeters</param>
        /// <returns>Collection of found objects (empty, if there were none)</returns>
        IList<T> Find(T searchParameeters);

        int Update(T dtoToIUpdate);
        
    }
}
