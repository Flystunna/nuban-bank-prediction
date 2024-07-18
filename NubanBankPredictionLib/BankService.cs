namespace NubanBankPredictionLib
{
    public static class BankService
    {
        public static List<T> GetPossibleBanks<T>(string accountNumber, List<T> banks) where T : Bank
        {
            return banks.Where(bank => BankAccountValidator.IsBankAccountValid(accountNumber, bank.Code)).ToList();
        }
    }
}
