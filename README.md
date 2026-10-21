# AmountToWordConverter

### A static utility class to convert numbers to words in multiple languages and currencies.

A self-contained C#/.NET 6 or .NET Framework 4.7.2 class library designed for easy integration into any .NET application, including those using VB.NET. It converts an amount (represented by two decimal numbers) into its word representation, handling multiple languages and currency formats.

> **Note:** The code is designed to be easily adaptable to almost any .NET Framework or .NET version.

---

### Key Features

* **Multi-language Support**: Automatically converts numbers to words in both **English** (en-US) and **Spanish** (es-MX).
* **Currency Handling**: Accurately formats currency for **USD** (dollars and cents) and **MXN** (pesos and centavos).
* **Negative Number Support**: Convert negative amounts with language-specific prefixes ("Negative" for English, "Negativo" for Spanish).
* **Plain Number Mode**: Convert plain numbers without currency words, with decimal representation using "point" (English) or "coma" (Spanish).
* **ConversionMode Enum**: Flexible `ConversionMode` parameter for `Currency_Dollar`, `Currency_Peso`, or `PlainNumber` conversions.
* **Extensible**: Easily extend the class to support additional languages or number scales.
* **Robust Logic**: Handles complex number conversions, including large numbers (millions, billions) and specific Spanish grammar rules (e.g., "veintiuno," "ciento" vs. "cien").

---

### How to Use

#### Installation (NuGet)
```
Install-Package NandoStyle.AmountToWords
```

Or search for `NandoStyle.AmountToWords` in the NuGet Package Manager.

#### Basic Usage

The library provides the `AmountToWordConverter` class with multiple overloads of the `ToWords` method:

**Currency Conversion (Backward Compatible):**
```csharp
using NandoStyle.AmountToWords;

decimal amount = 1234567890.50m;

// Convert to Spanish pesos
string spanishWords = AmountToWordConverter.ToWords(
    amount, 
    AmountToWordConverter.LanguageToUse.Spanish, 
    AmountToWordConverter.CurrencyToUse.Peso
);
// Output: "Un mil doscientos treinta y cuatro millones quinientos sesenta y siete mil ochocientos noventa pesos con cincuenta centavos"

// Convert to English dollars
string englishWords = AmountToWordConverter.ToWords(
    amount, 
    AmountToWordConverter.LanguageToUse.English, 
    AmountToWordConverter.CurrencyToUse.Dollar
);
// Output: "One billion two hundred thirty four million five hundred sixty seven thousand eight hundred ninety dollars and fifty cents"
```

**Using ConversionMode (New in v1.1.0):**
```csharp
// Plain number conversion (no currency)
string plainEN = AmountToWordConverter.ToWords(
    123.45m,
    AmountToWordConverter.LanguageToUse.English,
    AmountToWordConverter.ConversionMode.PlainNumber
);
// Output: "One hundred twenty three point forty five"

string plainES = AmountToWordConverter.ToWords(
    123.45m,
    AmountToWordConverter.LanguageToUse.Spanish,
    AmountToWordConverter.ConversionMode.PlainNumber
);
// Output: "Ciento veintitrés coma cuarenta y cinco"

// Negative numbers
string negativeEN = AmountToWordConverter.ToWords(
    -50.00m,
    AmountToWordConverter.LanguageToUse.English,
    AmountToWordConverter.ConversionMode.Currency_Dollar
);
// Output: "Negative fifty dollars"

string negativeES = AmountToWordConverter.ToWords(
    -50.00m,
    AmountToWordConverter.LanguageToUse.Spanish,
    AmountToWordConverter.ConversionMode.Currency_Peso
);
// Output: "Negativo cincuenta pesos"
```

#### Automated Testing

    This project also includes a self-contained automated test suite in the NumberTowordsAutomatedTester() method. This is useful for verifying that the conversion logic works correctly for various numbers and languages.
    
    To run the tests, call this static method from your application's startup.
    
        // Example in C#
        public static void Main()
        {
            Console.WriteLine(NumberToWordConverter.NumberTowordsAutomatedTester());
        }
   It will output the results to the console.

---

### WPF Example (MVVM)

`AmountToWordsConverter_dotNET_ApplicationExample` is a WPF application targeting .NET 9 for Windows. Open `AmountToWordsLibrary_dotNET\AmountToWordsLibrary.sln` in Visual Studio and set the WPF example as the startup project.

* **Models**: `Models\CurrencyOption.cs` holds a currency's enum value and display label. The existing `AmountToWordsLibrary_dotNET` library remains the domain model for conversion and automated test reports without changes.
* **Views**: `Views\MainWindow.xaml` defines the layout and binds its inputs, selections, results, and buttons to a `MainWindowViewModel` created in its `DataContext`. `Views\MainWindow.xaml.cs` only initializes the window. `App.xaml` stays at the application root and starts this view.
* **ViewModels**: `ViewModels\MainWindowViewModel.cs` implements `INotifyPropertyChanged` and exposes conversion and test commands. The conversion language and test language remain independent; currency selections use enum values with the existing Dollars/Pesos labels.
* **Commands**: `Commands\RelayCommand.cs` adapts view-model actions to WPF's `ICommand` without additional packages.

The amount starts at

---

### Contributing
We welcome improvements and contributions! If you find a bug or have a suggestion for an improvement, feel free to open an issue or submit a pull request.

---

### Support
If you find this project helpful and would like to support its continued development, you can donate via PayPal.
PayPal: nandostyle@gmail.com
