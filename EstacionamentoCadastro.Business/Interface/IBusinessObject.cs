using EstacionamentoCadastro.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoCadastro.Business.Interface
{
    public interface IBusinessObject<T, I> 
    {
        IDataAccessObject<T, I> data { get; set; }
        void Atualizar(T model);
        void Excluir(I id);
        void Incluir(T model);
        List<T> Listar();
        T ObterPorId(I id);
    }
}
