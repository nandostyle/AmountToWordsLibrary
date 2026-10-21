using System;
using NandoStyle.NumberToWordConverter;

class Program
{
    static void Main()
    {
        // Test negative amounts in Spanish
        Console.WriteLine("=== Spanish Tests ===");
        Console.WriteLine($"Spanish Peso -1.00: {AmountToWordConverter.ToWords(-1.00m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Peso)}");
        Console.WriteLine($"Spanish Peso -21.00: {AmountToWordConverter.ToWords(-21.00m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Peso)}");
        Console.WriteLine($"Spanish Peso -100.00: {AmountToWordConverter.ToWords(-100.00m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Peso)}");
        Console.WriteLine($"Spanish Peso -101.50: {AmountToWordConverter.ToWords(-101.50m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Peso)}");

        Console.WriteLine($"\nSpanish Dollar -1.00: {AmountToWordConverter.ToWords(-1.00m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Dollar)}");
        Console.WriteLine($"Spanish Dollar -21.00: {AmountToWordConverter.ToWords(-21.00m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Dollar)}");

        // Test negative amounts in English
        Console.WriteLine("\n=== English Tests ===");
        Console.WriteLine($"English Dollar -1.00: {AmountToWordConverter.ToWords(-1.00m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Dollar)}");
        Console.WriteLine($"English Dollar -21.00: {AmountToWordConverter.ToWords(-21.00m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Dollar)}");
        Console.WriteLine($"English Dollar -100.00: {AmountToWordConverter.ToWords(-100.00m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Dollar)}");
        Console.WriteLine($"English Dollar -101.50: {AmountToWordConverter.ToWords(-101.50m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Dollar)}");

        Console.WriteLine($"\nEnglish Peso -1.00: {AmountToWordConverter.ToWords(-1.00m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Peso)}");
        Console.WriteLine($"English Peso -21.00: {AmountToWordConverter.ToWords(-21.00m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Peso)}");

        // Test zero and positive to ensure backward compatibility
        Console.WriteLine("\n=== Backward Compatibility Tests ===");
        Console.WriteLine($"Spanish Peso 0.00: {AmountToWordConverter.ToWords(0m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Peso)}");
        Console.WriteLine($"English Dollar 1.00: {AmountToWordConverter.ToWords(1.00m, AmountToWordConverter.LanguageToUse.English, AmountToWordConverter.CurrencyToUse.Dollar)}");
        Console.WriteLine($"Spanish Dollar 21.00: {AmountToWordConverter.ToWords(21.00m, AmountToWordConverter.LanguageToUse.Spanish, AmountToWordConverter.CurrencyToUse.Dollar)}");

        Console.WriteLine("\nRunning automated tests...");
        Console.WriteLine(AmountToWordConverter.NumberTowordsAutomatedTester());
    }
}
