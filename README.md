# AmountToWordConverter

### A static utility class to convert numbers to words in multiple languages and currencies.

A self-contained C#/.NET 6 or .NET Framework 4.7.2 class library designed for easy integration into any .NET application, including those using VB.NET. It converts an amount (represented by two decimal numbers) into its word representation, handling multiple languages and currency formats.

> **Note:** The code is designed to be easily adaptable to almost any .NET Framework or .NET version.

---

### Key Features

* **Multi-language Support**: Automatically converts numbers to words in both **English** (en-US) and **Spanish** (es-MX).
* **Currency Handling**: Accurately formats currency for **USD** (dollars and cents) and **MXN** (pesos and centavos).
* **Extensible**: Easily extend the class to support additional languages or number scales.
* **Robust Logic**: Handles complex number conversions, including large numbers (millions, billions) and specific Spanish grammar rules (e.g., "veintiuno," "ciento" vs. "cien").

---

### How to Use
1. Installation
To use this converter in your .NET project, you should first compile it into a .dll file.

    * Create a new Class Library project in Visual Studio.
    
    * Add the NumberToWordConverter.cs file to your new project.
    
    * Build the project.

    * The output NumberToWordConverter.dll file will be in the bin/Debug (or bin/Release) folder.
    
    * In your main application (e.g., a VB.NET or C# project), add a reference to this .dll file.

3. Basic Usage
    The ToWords method serves as the primary entry point for the conversion. It requires a decimal number and a CultureInfo object to determine the language.
   ```csharp
    // Example in C#
    using System;
    using MyProject.NumberToWords; // Assuming this is your project's namespace
    //
    decimal amount = 1234567890.50m;
    // Convert the number to words in Spanish
    string spanishWords = NumberToWordConverter.ToWords(amount,LanguageToUse.Spanish, CurrencyToUse.Dollar);
    Console.WriteLine(spanishWords);
   // Output: "Mil doscientos treinta y cuatro millones quinientos sesenta y siete mil ochocientos noventa dólares con cincuenta centavos"


4. Automated Testing
    This project also includes a self-contained automated test suite in the NumberTowordsAutomatedTester() method. This is useful for verifying that the conversion logic works correctly for various numbers and languages.
    
    To run the tests, call this static method from your application's startup.
    
        // Example in C#
        public static void Main()
        {
            Console.WriteLine(NumberToWordConverter.NumberTowordsAutomatedTester());
        }
   It will output the results to the console.

---

### Contributing
We welcome improvements and contributions! If you find a bug or have a suggestion for an improvement, feel free to open an issue or submit a pull request.

---

### Support
If you find this project helpful and would like to support its continued development, you can donate via PayPal.
PayPal: nandostyle@gmail.com
