using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Handler.CPF
{
    public interface ICPFHandler
    {
        bool Handle(string cpf);
    }
}
