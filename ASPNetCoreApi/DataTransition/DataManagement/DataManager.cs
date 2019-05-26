using DataTransition.common.DTO;
using DataTransition.DTO;
using DataTransition.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTransition.DataManagement
{
    /// <summary>
    /// Singletone data manager for the API. Used to add, search and update database objects
    /// </summary>
    public class DataManager
    {
        private static DataManager instance;
        private IDAO<TeamDTO> teamDAO;
        private IDAO<UserDTO> userDAO;
        /// <summary>
        /// Current singletone instance of the Data Manager
        /// </summary>
        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataManager();
                }
                return instance;
            }

        }

        /// <summary>
        /// Data access object for Teams 
        /// </summary>
        public IDAO<TeamDTO> TeamDAO
        {
            get => teamDAO;
            set => teamDAO = value;
        }
        public IDAO<UserDTO> UserDAO
        {
            get => userDAO;
            set => userDAO = value;
        }

        /// <summary>
        /// Try to save a new object to the Database
        /// </summary>
        /// <param name="objectToSave">Object to save</param>
        /// <returns>Save action response code</returns>
        public int Save(BaseDTO objectToSave)
        {
            if (objectToSave is TeamDTO)
            {
                return teamDAO.Save(objectToSave as TeamDTO);
            }
            if(objectToSave is UserDTO)
            {
                return userDAO.Save(objectToSave as UserDTO);
            }
            // If no DAO  for saving was found, Bad Request code is returned
            return 400;
        }

        public IList<BaseDTO>Find(BaseDTO searchParamaters)
        {
            List<BaseDTO> listToReturn = new List<BaseDTO>();
            if (searchParamaters is TeamDTO)
            {
                IList<TeamDTO> teams = teamDAO.Find(searchParamaters as TeamDTO);
                foreach(TeamDTO team in teams)
                {
                    listToReturn.Add(team as BaseDTO);
                }
            }
            else if(searchParamaters is UserDTO)
            {
                IList<UserDTO> users = userDAO.Find(searchParamaters as UserDTO);

                foreach (UserDTO user in users)
                {
                    listToReturn.Add(user as BaseDTO);
                }
            }
            else
            {
                throw new Exception($"{searchParamaters} is invalid search object");
            }
            return listToReturn;
        }

        /// <summary>
        /// Try to save a new object to the Database
        /// </summary>
        /// <param name="objectToSave">Object to save</param>
        /// <returns>Save action response code</returns>
        public int Update(BaseDTO objectToSave)
        {
            if (objectToSave is TeamDTO)
            {
                return teamDAO.Update(objectToSave as TeamDTO);
            }
            if (objectToSave is UserDTO)
            {
                return userDAO.Update(objectToSave as UserDTO);
            }
            // If no DAO  for saving was found, Bad Request code is returned
            return 400;
        }

    }
}
