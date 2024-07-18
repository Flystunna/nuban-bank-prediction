using Newtonsoft.Json;

namespace NubanBankPredictionLib
{
    public static class BankService
    {
        public static List<Bank> GetPossibleBanks(string accountNumber, List<Bank>? banks = null)
        {
            if (banks == null)
            {
                banks = LoadBanksFromJson("BankList.json");
            }
            return banks.Where(bank => BankAccountValidator.IsBankAccountValid(accountNumber, bank.Code)).ToList();
        }
        public static List<Bank> LoadBanksFromJson(string filePath)
        {
            // Read the JSON file
            string jsonString = File.ReadAllText(filePath);
            // Deserialize the JSON data
            var bankList = JsonConvert.DeserializeObject<BankList>(jsonString);
            return bankList?.Data ?? new List<Bank>();
        }
    }
}
