using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    interface IObject
    {
        List<Object> Listar();
        void Salvar();
        void Adicionar();
        void Excluir();
    }
}
