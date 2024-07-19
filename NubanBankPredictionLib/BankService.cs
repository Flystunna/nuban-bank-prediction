using Newtonsoft.Json;

namespace NubanBankPredictionLib
{
    public static class BankService
    {
        public static async Task<List<Bank>> GetPossibleBanks(string accountNumber, List<Bank>? banks = null)
        {
            if (banks == null)
            {
                banks = await LoadBanksFromJson();
            }
            return banks.Where(bank => BankAccountValidator.IsBankAccountValid(accountNumber, bank.Code)).ToList();
        }
        public static async Task<List<Bank>> LoadBanksFromJson()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/flystunna/nuban-bank-prediction/master/NubanBankPredictionLib/BankList.json");
                    response.EnsureSuccessStatusCode();
                    string jsonData = await response.Content.ReadAsStringAsync();
                    BankList banks = JsonConvert.DeserializeObject<BankList>(jsonData) ?? new BankList();
                    return banks.Data ?? new List<Bank>();
                }
            }
            catch (Exception)
            {
                return new List<Bank>();
            }
        }
    }
}
