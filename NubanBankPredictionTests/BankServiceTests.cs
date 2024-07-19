using Newtonsoft.Json;
using NubanBankPredictionLib;

namespace NubanBankPredictionTests
{
    [TestClass]
    public class BankServiceTests
    {
        List<Bank> banks = [];

        [TestInitialize]
        public void TestInit()
        {
            string jsonFilePath = "BankList.json";
            banks = LoadBanksFromJson(jsonFilePath);
        }

        [TestMethod]
        public async Task ShouldReturnArrayOfBanksForValidAccountNumberWithoutPassingListOfBanks()
        {
            // Arrange
            string accountNumber = "0010246780";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.All(bank => bank.Name != null && bank.Code != null));
        }


        [TestMethod]
        public async Task ShouldReturnArrayOfBanksForValidAccountNumber()
        {
            // Arrange
            string accountNumber = "0010246780";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.All(bank => bank.Name != null && bank.Code != null));
        }

        [TestMethod]
        public async Task ShouldReturnEmptyArrayForInvalidAccountNumber()
        {
            // Arrange
            string accountNumber = "00000000xx";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode50515()
        {
            // Arrange
            string accountNumber = "5522116946";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "50515"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode999991()
        {
            // Arrange
            string accountNumber = "8106136519";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "999991"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode044()
        {
            // Arrange
            string accountNumber = "0010246780";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "044"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode221()
        {
            // Arrange
            string accountNumber = "0054556411";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "221"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode057()
        {
            // Arrange
            string accountNumber = "1012854016";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "057"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode058()
        {
            // Arrange
            string accountNumber = "0108024071";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "058"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode033()
        {
            // Arrange
            string accountNumber = "1018044721";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "033"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode011()
        {
            // Arrange
            string accountNumber = "2022323697";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "011"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode070()
        {
            // Arrange
            string accountNumber = "5600026567";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "070"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode214()
        {
            // Arrange
            string accountNumber = "2828744017";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "214"));
        }

        [TestMethod]
        public async Task ShouldIncludeBankCode058ForAccountNumber()
        {
            //Arrange
            string accountNumber = "0263874788";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "058"));
        }
        [TestMethod]
        public async Task ShouldIncludeBankCode068ForAccountNumber()
        {
            //Arrange
            string accountNumber = "5005801153";
            // Act
            var result = await BankService.GetPossibleBanks(accountNumber, banks);
            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Bank>));
            Assert.IsTrue(result.Any(bank => bank.Code == "068"));
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