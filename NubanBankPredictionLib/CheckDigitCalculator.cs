namespace NubanBankPredictionLib
{
    public static class CheckDigitCalculator
    {
        public static int ComputeCheckDigit(string bankCode, string serialNumber)
        {
            var bankCodeWeights = new[] { 3, 7, 3, 3, 7, 3 };
            var serialNumberWeights = new[] { 3, 7, 3, 3, 7, 3, 3, 7, 3 };

            int result = WeightedSumCalculator.CalculateWeightedSum(bankCode, bankCodeWeights)
                         + WeightedSumCalculator.CalculateWeightedSum(serialNumber, serialNumberWeights);

            int subtractionResult = 10 - (result % 10);

            return subtractionResult == 10 ? 0 : subtractionResult;
        }
    }

}
