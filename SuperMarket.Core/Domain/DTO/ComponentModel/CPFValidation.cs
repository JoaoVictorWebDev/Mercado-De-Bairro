using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Domain.DTO.ComponentModel
{
    public class CPFValidaton : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var cpf = value as string;

            if (!isValidCPF(cpf))
            {
                return new ValidationResult("CPF Inválido");
            }

            return ValidationResult.Success;
        }

        private bool isValidCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

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
