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
        /// Name of the object is allready taken. Sae operation canceled
        /// </summary>
        NameAllreadyTaken = 410
    }
}
