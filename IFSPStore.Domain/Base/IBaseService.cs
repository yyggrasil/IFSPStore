using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace IFSPStore.Domain.Base
{
    public interface IBaseService<TEntity> where TEntity : IBaseEntity
    {
        public void AttachObject(object obj);
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel: class
            where TOutputModel: class;

        void Delete(int id);

        IEnumerable<TOutputModel> get<TOutputModel>(IList<string>? includes = null)
            where TOutputModel : class;
        TOutputModel GetById<TOutputModel>(int id, IList<string>? includes = null);
        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
