using System.Collections.Generic;

namespace Microservices.Commands.Domain.Base.Validation
{
    public interface IBaseValidation
    {
        void AddError(IEnumerable<string> erros);

        void AddError(string erro);

        void AddError(BaseValidation baseValidation);

        public void AddError(IEnumerable<BaseValidation> baseValidation);

        ICollection<string> GetErrors();

        bool IsValid();
    }
}