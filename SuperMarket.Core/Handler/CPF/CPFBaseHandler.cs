using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Handler.CPF
{
    public class CPFBaseHandler : ICPFHandler
    {
        protected ICPFHandler _nextHandler;

        public void SetNext(ICPFHandler handler)
        {
            _nextHandler = handler;
        }

        public virtual bool Handle(string CPF)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(CPF);
            }
            return true;
        }
    }
}
