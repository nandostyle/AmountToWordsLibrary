using System.Text;
using System.Windows;
using static NandoStyle.NumberToWordConverter.AmountToWordConverter;

namespace NumberToWordsConverter_ApplicationExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestDollarsButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedLanguage = (LanguageToUse)AllTestsLanguageComboBox.SelectedIndex;
            AllTestResultsTextBox.Text = RunAutomatedTester(selectedLanguage, CurrencyToUse.Dollar);
        }

        private void TestPesosButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedLanguage = (LanguageToUse)AllTestsLanguageComboBox.SelectedIndex;
            AllTestResultsTextBox.Text = RunAutomatedTester(selectedLanguage, CurrencyToUse.Peso);
        }

        private void RunAllTestsButton_Click(object sender, RoutedEventArgs e)
        {
            var allResults = new StringBuilder();
            allResults.AppendLine("--- Running All Automated Tests ---");
            allResults.AppendLine();
            allResults.Append(NumberTowordsAutomatedTester());
            AllTestResultsTextBox.Text = allResults.ToString();
        }

        private void TestsButton_Click(object sender, RoutedEventArgs e)
        {
            //
            CurrencyToUse myCurrencyToUse = myCurrencyToUse = CurrencyToUse.Dollar;
            string? selectedCurrencyItem = CurrencyComboBox.SelectionBoxItem.ToString();
            //
            if (string.IsNullOrEmpty(selectedCurrencyItem)) return; //early departure.
            //
            if (selectedCurrencyItem == "Dolars")
            {
                myCurrencyToUse = CurrencyToUse.Dollar;
            }
            else if (selectedCurrencyItem == "Pesos")
            {
                myCurrencyToUse = CurrencyToUse.Peso;
            }
            //
            //
            LanguageToUse selectedLanguage = LanguageToUse.English;
            string? selectedLanguageItem = LanguageComboBox.SelectionBoxItem.ToString();
            //
            if (string.IsNullOrEmpty(selectedLanguageItem)) return; //early departure.
            //
            if (selectedLanguageItem == "English")
            {
                selectedLanguage = LanguageToUse.English;
            }
            else if (selectedLanguageItem == "Spanish")
            {
                selectedLanguage = LanguageToUse.Spanish;
            }
            //
            if (  Decimal.TryParse(InputNumberTextBox.Text, out decimal DecimalNumber))
            {
                ResultsTextBox.Text = ToWords(DecimalNumber, selectedLanguage, myCurrencyToUse);
            }
            else
            {
                ResultsTextBox.Text = "Invalid number format.";
            }
            //
        }
    }
}