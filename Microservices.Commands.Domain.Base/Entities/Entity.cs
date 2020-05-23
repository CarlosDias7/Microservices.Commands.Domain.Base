using Microservices.Commands.Domain.Base.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Commands.Domain.Base.Entities
{
    public class Entity : BaseValidation, IBaseValidation
    {
        protected Entity(Guid id)
        {
            SetId(id);
        }

        protected Entity()
        {
            SetId(Guid.NewGuid());
        }

        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Indice { get; set; }

        private void SetId(Guid id)
        {
            if (id == default)
            {
                AddError($"Não é possível inserir no Id o valor: {id}");
                return;
            }

            Id = id;
        }
    }
}