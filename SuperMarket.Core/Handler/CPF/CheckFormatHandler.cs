using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Handler.CPF
{
    public class CheckFormatHandler : CPFBaseHandler
    {
        public override bool Handle(string CPF)
        {
            CPF = new string(CPF.Where(char.IsDigit).ToArray());
            if (CPF.Length != 11)
            {
                return false;
            }

            return base.Handle(CPF);
        }
    }
}
