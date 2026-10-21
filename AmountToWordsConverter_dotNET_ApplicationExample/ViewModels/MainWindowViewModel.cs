using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using NumberToWordsConverter_ApplicationExample.Commands;
using NumberToWordsConverter_ApplicationExample.Models;
using static NandoStyle.AmountToWords.AmountToWordConverter;

namespace NumberToWordsConverter_ApplicationExample.ViewModels
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private string inputNumber = "12345.67";
        private LanguageToUse selectedLanguage = LanguageToUse.English;
        private CurrencyToUse selectedCurrency = CurrencyToUse.Dollar;
        private ConversionMode selectedConversionMode = ConversionMode.Currency_Dollar;
        private LanguageToUse selectedTestLanguage = LanguageToUse.English;
        private string results = string.Empty;
        private string allTestResults = string.Empty;

        public MainWindowViewModel()
        {
            ConvertCommand = new RelayCommand(ConvertAmount);
            ConvertPlainNumberCommand = new RelayCommand(ConvertPlainNumber);
            ConvertNegativeCommand = new RelayCommand(ConvertNegativeAmount);
            TestDollarsCommand = new RelayCommand(() => RunTests(CurrencyToUse.Dollar));
            TestPesosCommand = new RelayCommand(() => RunTests(CurrencyToUse.Peso));
            RunAllTestsCommand = new RelayCommand(RunAllTests);
            TestPlainNumbersCommand = new RelayCommand(TestPlainNumbers);
            TestNegativeAmountsCommand = new RelayCommand(TestNegativeAmounts);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public IReadOnlyList<LanguageToUse> Languages { get; } =
            Array.AsReadOnly(Enum.GetValues<LanguageToUse>());

        public IReadOnlyList<CurrencyOption> Currencies { get; } =
            Array.AsReadOnly(new[]
            {
                new CurrencyOption(CurrencyToUse.Dollar, "Dollars"),
                new CurrencyOption(CurrencyToUse.Peso, "Pesos")
            });

        public IReadOnlyList<ConversionModeOption> ConversionModes { get; } =
            Array.AsReadOnly(new[]
            {
                new ConversionModeOption(ConversionMode.Currency_Dollar, "Currency - Dollars"),
                new ConversionModeOption(ConversionMode.Currency_Peso, "Currency - Pesos"),
                new ConversionModeOption(ConversionMode.PlainNumber, "Plain Number")
            });

        public string InputNumber
        {
            get => inputNumber;
            set => SetProperty(ref inputNumber, value);
        }

        public LanguageToUse SelectedLanguage
        {
            get => selectedLanguage;
            set => SetProperty(ref selectedLanguage, value);
        }

        public CurrencyToUse SelectedCurrency
        {
            get => selectedCurrency;
            set => SetProperty(ref selectedCurrency, value);
        }

        public ConversionMode SelectedConversionMode
        {
            get => selectedConversionMode;
            set => SetProperty(ref selectedConversionMode, value);
        }

        public LanguageToUse SelectedTestLanguage
        {
            get => selectedTestLanguage;
            set => SetProperty(ref selectedTestLanguage, value);
        }

        public string Results
        {
            get => results;
            private set => SetProperty(ref results, value);
        }

        public string AllTestResults
        {
            get => allTestResults;
            private set => SetProperty(ref allTestResults, value);
        }

        public ICommand ConvertCommand { get; }
        public ICommand ConvertPlainNumberCommand { get; }
        public ICommand ConvertNegativeCommand { get; }
        public ICommand TestDollarsCommand { get; }
        public ICommand TestPesosCommand { get; }
        public ICommand RunAllTestsCommand { get; }
        public ICommand TestPlainNumbersCommand { get; }
        public ICommand TestNegativeAmountsCommand { get; }

        private void ConvertAmount()
        {
            Results = decimal.TryParse(InputNumber, out decimal amount)
                ? ToWords(amount, SelectedLanguage, SelectedConversionMode)
                : "Invalid number format.";
        }

        private void ConvertPlainNumber()
        {
            Results = decimal.TryParse(InputNumber, out decimal amount)
                ? ToWords(amount, SelectedLanguage, ConversionMode.PlainNumber)
                : "Invalid number format.";
        }

        private void ConvertNegativeAmount()
        {
            Results = decimal.TryParse(InputNumber, out decimal amount)
                ? ToWords(-Math.Abs(amount), SelectedLanguage, SelectedConversionMode)
                : "Invalid number format.";
        }

        private void RunTests(CurrencyToUse currency)
        {
            AllTestResults = RunAutomatedTester(SelectedTestLanguage, currency);
        }

        private void TestPlainNumbers()
        {
            var testResults = new StringBuilder();
            testResults.AppendLine("--- Testing Plain Numbers ---");
            testResults.AppendLine();

            var testNumbers = new decimal[] { 0m, 1m, 21m, 100m, 101m, 1000m, 21.5m, 100.25m, -1m, -21m, -100.5m };

            foreach (var num in testNumbers)
            {
                string english = ToWords(num, LanguageToUse.English, ConversionMode.PlainNumber);
                string spanish = ToWords(num, LanguageToUse.Spanish, ConversionMode.PlainNumber);

                testResults.AppendLine($"{num,10} => EN: {english}");
                testResults.AppendLine($"          => ES: {spanish}");
                testResults.AppendLine();
            }

            AllTestResults = testResults.ToString();
        }

        private void TestNegativeAmounts()
        {
            var testResults = new StringBuilder();
            testResults.AppendLine("--- Testing Negative Amounts ---");
            testResults.AppendLine();

            var testAmounts = new decimal[] { -1m, -21m, -100m, -101.50m, -1000m, -21.75m };

            testResults.AppendLine("Dollars (English):");
            foreach (var amount in testAmounts)
            {
                string result = ToWords(amount, LanguageToUse.English, ConversionMode.Currency_Dollar);
                testResults.AppendLine($"{amount,10} => {result}");
            }

            testResults.AppendLine();
            testResults.AppendLine("Pesos (Spanish):");
            foreach (var amount in testAmounts)
            {
                string result = ToWords(amount, LanguageToUse.Spanish, ConversionMode.Currency_Peso);
                testResults.AppendLine($"{amount,10} => {result}");
            }

            AllTestResults = testResults.ToString();
        }

        private void RunAllTests()
        {
            var allResults = new StringBuilder();
            allResults.AppendLine("--- Running All Automated Tests ---");
            allResults.AppendLine();
            allResults.Append(NumberTowordsAutomatedTester());
            AllTestResults = allResults.ToString();
        }

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
