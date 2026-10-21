using static NandoStyle.AmountToWords.AmountToWordConverter;

namespace NumberToWordsConverter_ApplicationExample.Models
{
    public sealed record ConversionModeOption(ConversionMode Value, string DisplayName);
}
