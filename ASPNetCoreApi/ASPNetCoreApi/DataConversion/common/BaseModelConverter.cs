using ASPNetCoreApi.Models.common;
using DataTransition.common.DTO;
using System.Collections.Generic;

namespace ASPNetCoreApi.DataConversion.common
{
    public abstract class BaseModelConverter<M,D>
        where M : BaseModel
        where D : BaseDTO
    {
        public abstract M GetModel(D dto);

        public IList<M> GetModel(IList<D> dtos)
        {
            List<M> models = new List<M>();
            foreach (D dto in dtos)
            {
                models.Add(GetModel(dto));
            }
            return models;
        }

        public abstract D GetDTO(M model);

        public IList<D> GetDTO(IList<M> models)
        {
            List<D> dtos = new List<D>();
            foreach(M model in models)
            {
                dtos.Add(GetDTO(model));
            }
            return dtos;
        }
    }
}
