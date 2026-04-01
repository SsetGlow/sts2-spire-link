namespace SpireLink.Runtime.Extensions;

public static class StringExtensions
{
    public static string CardImagePath(this string value) => $"res://SpireLink/images/card_portraits/{value}";
    public static string BigCardImagePath(this string value) => $"res://SpireLink/images/card_portraits/big/{value}";
    public static string RelicImagePath(this string value) => $"res://SpireLink/images/relics/{value}";
    public static string BigRelicImagePath(this string value) => $"res://SpireLink/images/relics/big/{value}";
}
