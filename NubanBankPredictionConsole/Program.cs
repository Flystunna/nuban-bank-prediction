// See https://aka.ms/new-console-template for more information
using NubanBankPredictionLib;

Console.WriteLine("Hello, World!");


var banks = await BankService.GetPossibleBanks("0263874788");

foreach (var bank in banks)
{
    Console.WriteLine(bank.Name);
}


Console.ReadKey();