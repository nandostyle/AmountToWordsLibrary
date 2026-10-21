using static AmountToWordsLibrary_dotNET.AmountToWordConverter;

namespace NumberToWordsConverter_ApplicationExample.Models
{
    public sealed record CurrencyOption(CurrencyToUse Value, string DisplayName);
}
