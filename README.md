# NUBAN Bank Prediction Algorithm

This utility function is designed to predict or identify the bank associated with a given Nigeria Uniform Bank Account Number (NUBAN). 
It validates NUBAN account numbers and provides possible banks that could own the account number.

This implementation is based on the Central Bank of Nigeria's [REVISED STANDARDS ON NIGERIA UNIFORM BANK ACCOUNT NUMBER (NUBAN) SCHEME FOR DEPOSIT MONEY BANKS (DMBs) AND OTHER FINANCIAL INSTITUTIONS (OFIs) IN NIGERIA - MAR 2020](https://www.cbn.gov.ng/out/2020/psmd/revised%20standards%20on%20nigeria%20uniform%20bank%20account%20number%20(nuban)%20for%20banks%20and%20other%20financial%20institutions%20.pdf).

Credits to https://github.com/03balogun for this idea

## Usage

The library has two classes `BankAccountValidator` and `BankService`.

BankAccountValidator exposes a method called IsBankAccountValid
### IsBankAccountValid

This function validates a given account number and bank code. It throws an error if the account number is not 10 digits long or if the bank code is not 3, 5 or 6 digits long. It returns `true` if the account number and bank code are valid and match, and `false` otherwise.

BankService exposes a method called GetPossibleBanks

```C#
bool isValid = BankAccountValidator.IsBankAccountValid("1234567890", "123"); // true
```

### GetPossibleBanks

This function returns an array of possible banks that could own a given account number. Each bank in the array is represented as an object with name and code properties. The name is the name of the bank and the code is the bank's code as per the CBN standards.

Here's an example of how you might use the function and what the response might look like:
```C#
var banks = BankService.GetPossibleBanks('0010246780'); // Array of possible banks
```
Output example:
```json
[
  {
    "name": "ACCESS BANK",
    "code": "044"
  },
  {
    "name": "First Bank PLC",
    "code": "011"
  }
]
```

You can also pass your own custom list of banks to the GetPossibleBanks method. The custom list should be an array of objects that match the Bank model. The bank model looks like this:


```C#
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
```

Here's an example:

```C#
var bankList = new List<Bank>(); //this should be your custom bank list

// Returns array of possible banks
var banks = BankService.GetPossibleBanks("0010246780", bankList);
```

