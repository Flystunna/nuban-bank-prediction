using NubanBankPredictionLib;

namespace NubanBankPredictionTests
{
    [TestClass]
    public class BankAccountValidatorTests
    {
        [TestMethod]
        public void ShouldThrowErrorIfAccountNumberIsNot10DigitsLong()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => BankAccountValidator.IsBankAccountValid("123456789", "123"),
                "Invalid account number, account number must be 10 digits long");
        }

        [TestMethod]
        public void ShouldThrowErrorIfBankCodeIsNot3Or5Or6DigitsLong()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => BankAccountValidator.IsBankAccountValid("1234567890", "12"),
                "Invalid bank code, bank code must be 3, 5 or 6 digits long");
        }

        [TestMethod]
        public void ShouldReturnTrueIfAccountNumberAndBankCodeAreValidAndMatch()
        {
            // Arrange & Act
            bool isValid = BankAccountValidator.IsBankAccountValid("0010246780", "044");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ShouldReturnFalseIfAccountNumberAndBankCodeAreValidButDoNotMatch()
        {
            // Arrange & Act
            bool isValid = BankAccountValidator.IsBankAccountValid("1234567890", "123");

            // Assert
            Assert.IsFalse(isValid);
        }
    }


}
