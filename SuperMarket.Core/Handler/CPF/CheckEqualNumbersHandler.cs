using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Handler.CPF
{
    public class CheckEqualNumbersHandler : CPFBaseHandler
    {
        public override bool Handle(string CPF)
        {
            if (CPF.Distinct().Count() == 1)
            {
                return false;
            }
            return base.Handle(CPF);
        }

    }
}
