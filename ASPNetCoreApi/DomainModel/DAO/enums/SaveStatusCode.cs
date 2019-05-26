namespace DomainModel.DAO.enums
{
    /// <summary>
    /// Operations statuses and codes for saving operations
    /// </summary>
    public enum SaveStatusCode
    {
        /// <summary>
        /// Object sussessfully saved
        /// </summary>
        SaveOK = 200,
        /// <summary>
        /// Name of the object is allready taken. Save operation canceled
        /// </summary>
        NameAllreadyTaken = 410,
        /// <summary>
        /// Entity to update was not found in database. Update canceled
        /// </summary>
        EntityToUpdateNotFound = 412,
        /// <summary>
        /// Attempt to update Entity with equal paramataers to other entities. Update canceled
        /// </summary>
        MultipleEntitiesToUpdateFound = 413


    }
}
