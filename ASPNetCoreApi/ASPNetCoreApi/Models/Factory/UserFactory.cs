using ASPNetCoreApi.Models.Factory.interfaces;
using System;
using System.Collections.Generic;

namespace ASPNetCoreApi.Models.Factory
{
    public class UserFactory : IModelFactory<UserModel>
    {

        public UserModel Get(IList<string> props)
        {
           if(props.Count != 2)
            {
                throw new Exception($"Incorrect props format. " +
                    $"Props count is {props.Count}, not needed 2");
            }
            return GetNewUser(props[0], props[1]);
        }

        public UserModel Get(int id, IList<string> props)
        {
            if (props.Count != 2)
            {
                throw new Exception($"Incorrect props format. " +
                        $"Props count is {props.Count}, not needed 2");
            }
            return GetExisitingUser(id,props[0], props[1]);
        }

        private UserModel GetNewUser(string login, string password)
        {
            return new UserModel(login, password);
        }

        private UserModel GetExisitingUser(int id, string login, string password)
        {
            return new UserModel(id, login, password);
        }

        public UserModel GetEmpty()
        {
            return new UserModel();
        }
    }
}
