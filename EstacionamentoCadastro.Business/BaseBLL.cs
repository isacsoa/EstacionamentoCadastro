using EstacionamentoCadastro.Business.Interface;
using EstacionamentoCadastro.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstacionamentoCadastro.Business
{
    public class BaseBLL<T, I> : IBusinessObject<T, I> 
    {
        public IDataAccessObject<T, I> data { get; set; }
        public BaseBLL(IDataAccessObject<T, I> d)
        {
            data = d;
        }

        public virtual void Atualizar(T model)
        {
            data.Atualizar(model);
        }

        public virtual void Excluir(I id)
        {
            data.Excluir(id);
        }

        public virtual void Incluir(T model)
        {
            data.Incluir(model);
        }

        public virtual List<T> Listar()
        {
            return data.Listar();
        }

        public virtual T ObterPorId(I id)
        {
            return data.ObterPorId(id);
        }

        public static ResultadoValidacao ValidarModel(object dados)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(dados);
            return new ResultadoValidacao
            {
                IsValid = Validator.TryValidateObject(dados, validationContext, results),
                ValidationResults = results
            };
        }

        public class ResultadoValidacao
        {
            public bool IsValid { get; set; }
            public ICollection<ValidationResult> ValidationResults { get; set; }
        }
    }
}
