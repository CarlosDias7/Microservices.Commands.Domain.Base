using System.Collections.Generic;
using System.Linq;

namespace Microservices.Commands.Domain.Base.Validation
{
    public class BaseValidation : IBaseValidation
    {
        private ICollection<string> _errors;

        public BaseValidation()
        {
            _errors = new List<string>();
        }

        public void AddError(string erro)
        {
            _errors ??= new List<string>();
            _errors.Add(erro);
        }

        public void AddError(IEnumerable<string> errors)
        {
            _errors ??= new List<string>();
            foreach (var error in errors) AddError(error);
        }

        public void AddError(BaseValidation baseValidation) =>
            AddError(baseValidation?.GetErrors());

        public void AddError(IEnumerable<BaseValidation> baseValidation) =>
            baseValidation?.ToList().ForEach(x => AddError(x));

        public ICollection<string> GetErrors() => _errors;

        public virtual bool IsValid()
        {
            if (_errors is null) return false;
            return !_errors.Any();
        }
    }
}