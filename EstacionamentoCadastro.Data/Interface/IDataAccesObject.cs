using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoCadastro.Data.Interface
{
    public interface IDataAccessObject<T, I> 
    {
        void Atualizar(T model);
        void Excluir(I id);
        void Incluir(T model);
        List<T> Listar();
        T ObterPorId(I id);
    }
}
