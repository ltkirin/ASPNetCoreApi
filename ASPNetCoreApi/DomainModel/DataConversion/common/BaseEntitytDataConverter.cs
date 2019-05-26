using DataTransition.common.DTO;
using DomainModel.Entity.common;
using System.Collections.Generic;

namespace DomainModel.DataConversion.common
{
    /// <summary>
    /// Base class for Entity-DTO data converter
    /// </summary>
    /// <typeparam name="E">Entity-based Type</typeparam>
    /// <typeparam name="D">DTO-based Type</typeparam>
    public abstract class BaseEntityConverter<E,D> 
        where E : EntityBase
        where D : BaseDTO
    {
        /// <summary>
        /// Convert DTO to Entity
        /// </summary>
        /// <param name="dto">DTO to convert</param>
        /// <returns>Converted Entity</returns>
        public abstract E GetEntity(D dto);

        /// <summary>
        /// Convert Collection of DTos to collection of Entites
        /// </summary>
        /// <param name="dtos">DTOs collection</param>
        /// <returns>Entites co0llection</returns>
        public IList<E> GetEntity(IList<D> dtos)
        {
            List<E> entites = new List<E>();
            foreach(D dto in dtos)
            {
                entites.Add(GetEntity(dto));
            }
            return entites;
        }

        /// <summary>
        /// Convert Entity to DTO
        /// </summary>
        /// <param name="entity">Entity to convert</param>
        /// <returns>Converted DTO</returns>
        public abstract D GetDTO(E entity);

        /// <summary>
        ///  Convert Collection of Entites to collection of DTos
        /// </summary>
        /// <param name="entities">Entites to convert</param>
        /// <returns>Collection of DTos</returns>
        public IList<D> GetDTO(IList<E> entities)
        {
            List<D> dtos = new List<D>();
            foreach (E entity in entities)
            {
                dtos.Add(GetDTO(entity));
            }
            return dtos;
        }

    }
}
