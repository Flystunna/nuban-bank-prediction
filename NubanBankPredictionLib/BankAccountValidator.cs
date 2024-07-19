using System;
using System.Text.RegularExpressions;
namespace NubanBankPredictionLib
{
    public static class BankAccountValidator
    {
        public static bool IsBankAccountValid(string accountNumber, string bankCode)
        {
            if (accountNumber.Length != 10)
            {
                throw new ArgumentException("Invalid account number, account number must be 10 digits long");
            }

            string paddedBankCode = Regex.Replace(bankCode, @"\D", "");

            if (paddedBankCode.Length == 3)
            {
                paddedBankCode = $"000{paddedBankCode}";
            }
            else if (paddedBankCode.Length == 5)
            {
                paddedBankCode = $"9{paddedBankCode}";
            }

            if (paddedBankCode.Length != 6)
            {
                throw new ArgumentException($"Invalid bank code, bank code must be 3, 5 or 6 digits long. {paddedBankCode} is {paddedBankCode.Length} digits long");
            }

            string serialNumber = accountNumber.Substring(0, 9);
            char accountCheckDigit = accountNumber[9];
            int checkDigit = CheckDigitCalculator.ComputeCheckDigit(paddedBankCode, serialNumber);

            return checkDigit.ToString() == accountCheckDigit.ToString();
        }
    }

}
