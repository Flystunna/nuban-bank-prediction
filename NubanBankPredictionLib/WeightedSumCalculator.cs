using System;
using System.Linq;

namespace NubanBankPredictionLib
{
    public class WeightedSumCalculator
    {
        public static readonly int[] BankCodeWeights = { 3, 7, 3, 3, 7, 3 };
        public static readonly int[] SerialNumberWeights = { 3, 7, 3, 3, 7, 3, 3, 7, 3 };
        public static int CalculateWeightedSum(string value, int[] weights)
        {
            if (value.Length != weights.Length)
            {
                throw new ArgumentException("Value and weights must have the same length");
            }

            return value
                .Select((digit, index) => (digit - '0') * weights[index])
                .Sum();
        }
    }

}
