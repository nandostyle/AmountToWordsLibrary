using static NandoStyle.AmountToWords.AmountToWordConverter;

namespace NumberToWordsConverter_ApplicationExample.Models
{
    public sealed record CurrencyOption(CurrencyToUse Value, string DisplayName);
}
