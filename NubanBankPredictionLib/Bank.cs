using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NubanBankPredictionLib
{
    public class Bank
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public Bank(string name, string code)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
    public class BankList
    {
        [JsonProperty("data")]
        public List<Bank>? Data { get; set; }
    }
}
