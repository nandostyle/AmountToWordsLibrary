using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using NumberToWordsConverter_ApplicationExample.Commands;
using NumberToWordsConverter_ApplicationExample.Models;
using static AmountToWordsLibrary_dotNET.AmountToWordConverter;

namespace NumberToWordsConverter_ApplicationExample.ViewModels
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private string inputNumber = "12345.67";
        private LanguageToUse selectedLanguage = LanguageToUse.English;
        private CurrencyToUse selectedCurrency = CurrencyToUse.Dollar;
        private LanguageToUse selectedTestLanguage = LanguageToUse.English;
        private string results = string.Empty;
        private string allTestResults = string.Empty;

        public MainWindowViewModel()
        {
            ConvertCommand = new RelayCommand(ConvertAmount);
            TestDollarsCommand = new RelayCommand(() => RunTests(CurrencyToUse.Dollar));
            TestPesosCommand = new RelayCommand(() => RunTests(CurrencyToUse.Peso));
            RunAllTestsCommand = new RelayCommand(RunAllTests);
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
        public ICommand TestDollarsCommand { get; }
        public ICommand TestPesosCommand { get; }
        public ICommand RunAllTestsCommand { get; }

        private void ConvertAmount()
        {
            Results = decimal.TryParse(InputNumber, out decimal amount)
                ? ToWords(amount, SelectedLanguage, SelectedCurrency)
                : "Invalid number format.";
        }

        private void RunTests(CurrencyToUse currency)
        {
            AllTestResults = RunAutomatedTester(SelectedTestLanguage, currency);
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
