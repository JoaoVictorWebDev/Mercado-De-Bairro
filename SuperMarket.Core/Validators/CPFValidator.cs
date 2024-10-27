using SuperMarket.Core.Handler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Validators
{
    public class CPFValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpf = value as string;

            if (string.IsNullOrEmpty(cpf))
            {
                return new ValidationResult("CPF não pode ser nulo ou vazio.");
            }

            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            if (!IsValidCPF(cpf))
            {
                return new ValidationResult("CPF inválido.");
            }

            return ValidationResult.Success;
        }

        private bool IsValidCPF(string cpf)
        {
            if (cpf.Length != 11)
            {
                return false;
            }

            if (cpf.Distinct().Count() == 1)
            {
                return false; 
            }

            var firstDigit = CalculateCPFDigit(cpf.Substring(0, 9));
            var secondDigit = CalculateCPFDigit(cpf.Substring(0, 10));

            return cpf.EndsWith($"{firstDigit}{secondDigit}");
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
