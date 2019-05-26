using ASPNetCoreApi.Models;
using ASPNetCoreApi.Models.common;
using DataTransition.common.DTO;
using DataTransition.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreApi.DataConversion
{
    public class ModelConverter
    {
        private static ModelConverter instance;
        private TeamsConverter teamsConverter;
        private UserConverter userConverter;

        public ModelConverter()
        {
            teamsConverter = new TeamsConverter();
            userConverter = new UserConverter(teamsConverter);
        }

        public static ModelConverter Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ModelConverter();
                }
                return instance;
            }
        }

        public BaseDTO GetDTO(BaseModel model)
        {
            if (model is UserModel)
            {
                return userConverter.GetDTO(model as UserModel);
            }
            if (model is TeamModel)
            {
                return teamsConverter.GetDTO(model as TeamModel);
            }
            throw new Exception($"{model} is invalid object for convertation!");
        }

        public IList<BaseDTO> GetDTO(IList<BaseModel> model)
        {

            if (model is IList<UserModel>)
            {
                if ((model as IList<UserModel>).Any())
                {
                    return userConverter.GetDTO(model as IList<UserModel>) as IList<BaseDTO>;
                }
                return new List<UserDTO>() as IList<BaseDTO>;
            }
            if (model is IList<TeamModel>)
            {
                if ((model as IList<UserModel>).Any())
                {
                    return teamsConverter.GetDTO(model as IList<TeamModel>) as IList<BaseDTO>;
                }
                return new List<TeamDTO>() as IList<BaseDTO>;
            }
            throw new Exception($"{model} is invalid object for convertation!");

        }

        public BaseModel GetModel(BaseDTO dto)
        {
            if (dto is UserDTO)
            {
                return userConverter.GetModel(dto as UserDTO);
            }
            if (dto is TeamDTO)
            {
                return teamsConverter.GetModel(dto as TeamDTO);
            }
            throw new Exception($"{dto} is invalid object for convertation!");
        }

        public IList<BaseModel> GetModel(IList<BaseDTO> dto)
        {
            if (dto is IList<UserDTO>)
            {
                if ((dto as IList<UserDTO>).Any())
                {
                    return userConverter.GetModel(dto as IList<UserDTO>) as IList<BaseModel>;
                }
                else return new List<UserModel>() as IList<BaseModel>;
            }
            if (dto is IList<TeamDTO>)
            {
                if ((dto as IList<TeamDTO>).Any())
                {
                    return teamsConverter.GetModel(dto as IList<TeamDTO>) as IList<BaseModel>;
                }
                else return new List<TeamModel>() as IList<BaseModel>;
            }
            throw new Exception($"{dto} is invalid object for convertation!");
        }
    }
}
