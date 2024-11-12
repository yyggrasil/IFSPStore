using AutoMapper;
using FluentValidation;
using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : IBaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper) 
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(entity);
            var outputModel = _mapper.Map< TOutputModel > (entity);
            return outputModel;
        }

        public void AttachObject(object obj)
        {
            _baseRepository.AtachObject(obj);
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IEnumerable<TOutputModel> get<TOutputModel>(IList<string>? includes = null) where TOutputModel : class
        {
            var entities = _baseRepository.Select(includes);
            var outputModel = entities.Select(s=>_mapper.Map<TOutputModel> (s));
            return outputModel;
        }

        public TOutputModel GetById<TOutputModel>(int id, IList<string>? includes = null)
        {
            var entity = _baseRepository.Select(id, includes);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
            {
                throw new Exception("Objeto invalido!");
            }
            validator.ValidateAndThrow(obj);
        }
    }
}
