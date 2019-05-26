using DataTransition.DTO;
using DataTransition.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransition.Service
{
    public class AuthorizationService
    {
        private static AuthorizationService instance;

        private IUserContext userContext;

        public static AuthorizationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthorizationService();
                }
                return instance;
            }
        }

        public IUserContext UserContext
        {
            get => userContext;
            set => userContext = value;
        }

        public bool UserAuthorised(UserDTO user)
        {
            return userContext.Authorised(user);
        }
    }
}
