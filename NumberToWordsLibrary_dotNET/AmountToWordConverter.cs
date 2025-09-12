using System.Text;
using System.Text.RegularExpressions;

namespace NandoStyle.NumberToWordConverter
{
    /// <summary>
    /// A static utility class for .NET 6.0 and higher, to convert decimal numbers into their currency word representation
    /// for both English and Spanish. The class is self-contained and does not rely on external resources.
    /// </summary>
    public static class AmountToWordConverter
    {
        #region Word Arrays

        private static readonly string[] en_Ones = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] en_Tens = new string[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static readonly string[] es_Ones = new string[] { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte", "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve" };
        private static readonly string[] es_Tens = new string[] { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static readonly string[] es_Hundreds = new string[] { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        #endregion Word Arrays

        /// <summary>
        /// The main entry point for the conversion. It checks the application's culture
        /// and routes the request to the appropriate language-specific method.
        /// </summary>
        /// <param name="number">The decimal number to convert.</param>
        /// <param name="language">The currency context (not used for logic in this version).</param>
        /// <param name="CurrencyToUse">: Peso, Dollars, pluralization is handled automatically.</param>
        public enum LanguageToUse
        {
            English,
            Spanish
        }

        public enum CurrencyToUse
        {
            Dollar,
            Peso
        }

        public static string ToWords(decimal number, LanguageToUse language, CurrencyToUse CurrencyToUse)
        {
            if (language == LanguageToUse.Spanish)
            {
                return ToWordsSpanish(number, CurrencyToUse);
            }
            return ToWordsEnglish(number, CurrencyToUse);
        }

        #region Spanish Conversion Logic

        private static string ToWordsSpanish(decimal number, CurrencyToUse currencyToUse)
        {
            try
            {
                string singularCurrency = "peso";
                string pluralCurrency = "pesos";
                string singularSubCurrency = "centavo";
                string pluralSubCurrency = "centavos";

                if (currencyToUse == CurrencyToUse.Dollar)
                {
                    singularCurrency = "dólar";
                    pluralCurrency = "dólares";
                    singularSubCurrency = "centavo";
                    pluralSubCurrency = "centavos";
                }

                if (number == 0)
                {
                    return $"Cero {pluralCurrency}";
                }

                long wholePart = (long)Math.Truncate(number);
                int decimalPart = (int)Math.Round((number - wholePart) * 100);

                var sb = new StringBuilder();

                if (wholePart > 0)
                {
                    string numberWords = ConvertNumberSpanish(wholePart);
                    sb.Append(numberWords);

                    // The preposition "de" is used with "millón/millones" when they are not followed by other numbers.
                    if ((numberWords.EndsWith("millón") || numberWords.EndsWith("millones")) && wholePart % 1000000 == 0)
                    {
                        sb.Append(" de");
                    }
                    sb.Append(wholePart == 1 ? $" {singularCurrency}" : $" {pluralCurrency}");
                }

                if (decimalPart > 0)
                {
                    if (wholePart > 0) sb.Append(" con ");
                    sb.Append(ConvertNumberSpanish(decimalPart));
                    sb.Append(decimalPart == 1 ? $" {singularSubCurrency}" : $" {pluralSubCurrency}");
                }

                string result = sb.ToString().Trim();
                return char.ToUpper(result[0]) + result.Substring(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Most likely you entered a too large number. Error: " + ex.Message);
                return string.Empty;
            }
        }

        private static string ConvertNumberSpanish(long number)
        {
            if (number == 0) return "cero";

            var words = new StringBuilder();

            // Handle millions
            if ((number / 1000000) > 0)
            {
                long millionsPart = number / 1000000;
                if (millionsPart == 1)
                {
                    words.Append("un millón ");
                }
                else
                {
                    words.Append(ConvertNumberSpanish(millionsPart) + " millones ");
                }
                number %= 1000000;
            }

            // Handle thousands
            if ((number / 1000) > 0)
            {
                long thousandsPart = number / 1000;
                if (thousandsPart == 1)
                {
                    words.Append("mil ");
                }
                else
                {
                    words.Append(ConvertUpto999Spanish(thousandsPart, true) + " mil ");
                }
                number %= 1000;
            }

            // Handle hundreds, tens, and ones
            if (number > 0)
            {
                words.Append(ConvertUpto999Spanish(number, true));
            }

            return words.ToString().Trim();
        }


        private static string ConvertUpto999Spanish(long number, bool applyApocope)
        {
            if (number == 100) return "cien";

            var sb = new StringBuilder();
            long hundreds = number / 100;
            long tensAndOnes = number % 100;

            if (hundreds > 0)
            {
                sb.Append(es_Hundreds[hundreds]);
            }

            if (tensAndOnes > 0)
            {
                if (hundreds > 0) sb.Append(" ");
                if (tensAndOnes < 30)
                {
                    sb.Append(es_Ones[tensAndOnes]);
                }
                else
                {
                    long tens = tensAndOnes / 10;
                    long ones = tensAndOnes % 10;
                    sb.Append(es_Tens[tens]);
                    if (ones > 0)
                    {
                        sb.Append($" y {es_Ones[ones]}");
                    }
                }
            }
            string result = sb.ToString();

            // Apply apocope (shortening of "uno" to "un" and "veintiuno" to "veintiún")
            if (applyApocope)
            {
                if (result.Equals("veintiuno"))
                {
                    return "veintiún";
                }
                if (result.EndsWith("uno"))
                {
                    // Handles "ciento uno" -> "ciento un", "treinta y uno" -> "treinta y un"
                    return result.Substring(0, result.Length - 1);
                }
            }
            return result;
        }

        #endregion Spanish Conversion Logic

        #region English Conversion Logic

        private static string ToWordsEnglish(decimal number, CurrencyToUse currencyToUse)
        {
            try
            {
                string singularCurrency = "dollar";
                string pluralCurrency = "dollars";
                string singularSubCurrency = "cent";
                string pluralSubCurrency = "cents";

                if (currencyToUse == CurrencyToUse.Peso)
                {
                    singularCurrency = "peso";
                    pluralCurrency = "pesos";
                    singularSubCurrency = "cent";
                    pluralSubCurrency = "cents";
                }

                if (number == 0)
                {
                    return string.Format("Zero {0}", pluralCurrency);
                }

                long wholePart = (long)Math.Truncate(number);
                int decimalPart = (int)Math.Round((number - wholePart) * 100);

                var sb = new StringBuilder();

                if (wholePart > 0)
                {
                    sb.Append(ConvertNumberEnglish(wholePart));
                    sb.Append(wholePart == 1 ? string.Format(" {0}", singularCurrency) : string.Format(" {0}", pluralCurrency));
                }

                if (decimalPart > 0)
                {
                    if (wholePart > 0) sb.Append(" and ");
                    sb.Append(ConvertNumberEnglish(decimalPart));
                    sb.Append(decimalPart == 1 ? string.Format(" {0}", singularSubCurrency) : string.Format(" {0}", pluralSubCurrency));
                }

                string result = sb.ToString().Trim();
                return char.ToUpper(result[0]) + result.Substring(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Most likely you entered a too large number. Error: " + ex.Message);
                return string.Empty;
            }
        }

        private static string ConvertNumberEnglish(long number)
        {
            if (number == 0) return "zero";

            var words = new StringBuilder();
            if ((number / 1000000000) > 0)
            {
                words.Append(ConvertNumberEnglish(number / 1000000000) + " billion ");
                number %= 1000000000;
            }
            if ((number / 1000000) > 0)
            {
                words.Append(ConvertNumberEnglish(number / 1000000) + " million ");
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words.Append(ConvertNumberEnglish(number / 1000) + " thousand ");
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words.Append(ConvertNumberEnglish(number / 100) + " hundred ");
                number %= 100;
            }
            if (number > 0)
            {
                if (words.Length > 0 && (number < 100 && number % 100 != 0)) words.Append("and ");
                if (number < 20)
                {
                    words.Append(en_Ones[number]);
                }
                else
                {
                    words.Append(en_Tens[number / 10]);
                    if ((number % 10) > 0)
                        words.Append("-" + en_Ones[number % 10]);
                }
            }
            return words.ToString().Trim();
        }

        #endregion English Conversion Logic

        #region "Automated Tester"

        private static readonly Dictionary<LanguageToUse, Dictionary<CurrencyToUse, Dictionary<decimal, string>>> TestCases =
        new Dictionary<LanguageToUse, Dictionary<CurrencyToUse, Dictionary<decimal, string>>>
        {
                // Top-level dictionary, keyed by language.
                {
                    LanguageToUse.Spanish, new Dictionary<CurrencyToUse, Dictionary<decimal, string>>
                    {
                        // Nested dictionary for Spanish, keyed by currency.
                        {
                            CurrencyToUse.Peso, new Dictionary<decimal, string>
                            {
                                // Innermost dictionary contains the test cases: decimal number mapped to the expected word string.
                                { 0m, "Cero pesos" },
                                { 1.00m, "Un peso" },
                                { 21.00m, "Veintiún pesos" },
                                { 100.00m, "Cien pesos" },
                                { 101.50m, "Ciento un pesos con cincuenta centavos" },
                                { 1000.00m, "Mil pesos" },
                                { 1001.00m, "Mil un pesos" },
                                { 2000.00m, "Dos mil pesos" },
                                { 1000000.00m, "Un millón de pesos" },
                                { 2000000.00m, "Dos millones de pesos" },
                                { 1151021.21m, "Un millón ciento cincuenta y un mil veintiún pesos con veintiún centavos" },
                                { 1000005150.79m, "Mil millones cinco mil ciento cincuenta pesos con setenta y nueve centavos" },
                                { 1234567890.50m, "Mil doscientos treinta y cuatro millones quinientos sesenta y siete mil ochocientos noventa pesos con cincuenta centavos" },
                                { 330015551000.02m, "Trescientos treinta mil quince millones quinientos cincuenta y un mil pesos con dos centavos" }
                            }
                        },
                        {
                            CurrencyToUse.Dollar, new Dictionary<decimal, string>
                            {
                                { 0m, "Cero dólares" },
                                { 1.00m, "Un dólar" },
                                { 21.00m, "Veintiún dólares" },
                                { 100.00m, "Cien dólares" },
                                { 101.50m, "Ciento un dólares con cincuenta centavos" },
                                { 1000.00m, "Mil dólares" },
                                { 1001.00m, "Mil un dólares" },
                                { 2000.00m, "Dos mil dólares" },
                                { 1000000.00m, "Un millón de dólares" },
                                { 2000000.00m, "Dos millones de dólares" },
                                { 1151021.21m, "Un millón ciento cincuenta y un mil veintiún dólares con veintiún centavos" },
                                { 1000005150.79m, "Mil millones cinco mil ciento cincuenta dólares con setenta y nueve centavos" },
                                { 1234567890.50m, "Mil doscientos treinta y cuatro millones quinientos sesenta y siete mil ochocientos noventa dólares con cincuenta centavos" },
                                { 330015551000.02m, "Trescientos treinta mil quince millones quinientos cincuenta y un mil dólares con dos centavos" }
                            }
                        }
                    }
                },
                {
                    LanguageToUse.English, new Dictionary<CurrencyToUse, Dictionary<decimal, string>>
                    {
                        {
                            CurrencyToUse.Dollar, new Dictionary<decimal, string>
                            {
                                { 0m, "Zero dollars" },
                                { 1.00m, "One dollar" },
                                { 21.00m, "Twenty-one dollars" },
                                { 100.00m, "One hundred dollars" },
                                { 101.50m, "One hundred and one dollars and fifty cents" },
                                { 1000.00m, "One thousand dollars" },
                                { 1001.00m, "One thousand and one dollars" },
                                { 2000.00m, "Two thousand dollars" },
                                { 1000000.00m, "One million dollars" },
                                { 1151021.21m, "One million one hundred and fifty-one thousand and twenty-one dollars and twenty-one cents" },
                                { 1000005150.79m , "One billion five thousand one hundred and fifty dollars and seventy-nine cents" },
                                { 1234567890.50m, "One billion two hundred and thirty-four million five hundred and sixty-seven thousand eight hundred and ninety dollars and fifty cents" },
                                { 330015551000.02m, "Three hundred and thirty billion fifteen million five hundred and fifty-one thousand dollars and two cents" }
                            }
                        },
                        {
                            CurrencyToUse.Peso, new Dictionary<decimal, string>
                            {
                                { 0m, "Zero pesos" },
                                { 1.00m, "One peso" },
                                { 21.00m, "Twenty-one pesos" },
                                { 100.00m, "One hundred pesos" },
                                { 101.50m, "One hundred and one pesos and fifty cents" },
                                { 1000.00m, "One thousand pesos" },
                                { 1001.00m, "One thousand and one pesos" },
                                { 2000.00m, "Two thousand pesos" },
                                { 1000000.00m, "One million pesos" },
                                { 1151021.21m, "One million one hundred and fifty-one thousand and twenty-one pesos and twenty-one cents" },
                                { 1000005150.79m , "One billion five thousand one hundred and fifty pesos and seventy-nine cents" },
                                { 1234567890.50m, "One billion two hundred and thirty-four million five hundred and sixty-seven thousand eight hundred and ninety pesos and fifty cents" },
                                { 330015551000.02m, "Three hundred and thirty billion fifteen million five hundred and fifty-one thousand pesos and two cents" }
                            }
                        }
                    }
                }
        };

        // Main function to run automated tests for a specific language and currency combination.
        public static string RunAutomatedTester(LanguageToUse language, CurrencyToUse currency)
        {
            StringBuilder Results = new StringBuilder();

            // Check if the requested language and currency combination exists in the TestCases dictionary.
            if (TestCases.ContainsKey(language) && TestCases[language].ContainsKey(currency))
            {
                // Get the dictionary of test cases for the specified language and currency.
                var testCases = TestCases[language][currency];

                // Add a header to the results string to indicate which test suite is running.
                Results.AppendLine($"--- Testing {language} ({currency}) ---");

                // Iterate through each key-value pair in the test suite.
                foreach (var test in testCases)
                {
                    // Call the main conversion method with the test number, language, and currency.
                    string result = AmountToWordConverter.ToWords(test.Key, language, currency);

                    // Compare the actual result with the expected result and determine PASS or FAIL.
                    string status = (result == test.Value) ? "PASS" : "FAIL";

                    // Append the test result to the string, showing the input, the actual output, and the status.
                    Results.AppendLine(string.Format("{0} => {1} ({2})", test.Key, result, status));
                }
            }
            else
            {
                // If the test suite doesn't exist, append a message indicating this.
                Results.AppendLine($"No test suite found for Language: {language} and Currency: {currency}.");
            }

            // Print the accumulated results to the console.
            return Results.ToString();
        }

        // Function to run ALL defined test suites.
        public static string NumberTowordsAutomatedTester()
        {
            StringBuilder AllResults = new StringBuilder();
            // Call the parameterized tester method for each language and currency combination to run all tests.
            AllResults.Append(RunAutomatedTester(LanguageToUse.Spanish, CurrencyToUse.Peso));
            AllResults.Append(Environment.NewLine + Environment.NewLine);
            AllResults.Append(RunAutomatedTester(LanguageToUse.Spanish, CurrencyToUse.Dollar));
            AllResults.Append(Environment.NewLine + Environment.NewLine);
            AllResults.Append(RunAutomatedTester(LanguageToUse.English, CurrencyToUse.Dollar));
            AllResults.Append(Environment.NewLine + Environment.NewLine);
            AllResults.Append(RunAutomatedTester(LanguageToUse.English, CurrencyToUse.Peso));
            //
            return AllResults.ToString();
        }

        #endregion "Automated Tester"

        #region "Supporting Classes"

        public class ThisCurrencyItem
        {
            public string? CurrencyISOCode { get; set; }
            public string? CurrencyDescription { get; set; }
            public decimal CurrencyPriceInUSD { get; set; }
            public int CurrencyIsDefault { get; set; }
            public DateTime? CurrencyLastModifiedOn { get; set; }

            public ThisCurrencyItem()
            {
            }

            public ThisCurrencyItem(string ISOCode, string Description, decimal PriceInUSD, int IsDefault, DateTime? LastModifiedOn)
            {
                CurrencyISOCode = ISOCode.Trim();
                CurrencyDescription = Description.Trim();
                CurrencyPriceInUSD = PriceInUSD;
                CurrencyIsDefault = IsDefault;
                CurrencyLastModifiedOn = LastModifiedOn;
            }
        }

        #endregion "Supporting Classes"
    }
}