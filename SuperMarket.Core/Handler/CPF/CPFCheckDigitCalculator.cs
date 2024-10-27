using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Handler.CPF
{
    public class CPFCheckDigitCalculator : CPFBaseHandler
    {
        public override bool Handle(string cpf)
        {
            var firstDigit = CalculateCPFDigit(cpf.Substring(0, 9));
            var secondDigit = CalculateCPFDigit(cpf.Substring(0, 10));

            if (!cpf.EndsWith($"{firstDigit}{secondDigit}"))
            {
                return false;
            }

            return base.Handle(cpf); // Passa para o próximo handler
        }

        private int CalculateCPFDigit(string cpf)
        {
            var sum = 0;
            for (int i = 0; i < cpf.Length; i++)
            {
                sum += (cpf.Length + 1 - i) * int.Parse(cpf[i].ToString());
            }

            var remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }

}
