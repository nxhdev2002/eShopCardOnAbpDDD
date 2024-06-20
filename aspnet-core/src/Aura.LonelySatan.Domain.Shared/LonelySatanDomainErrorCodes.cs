namespace Aura.LonelySatan;

public static class LonelySatanDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public const string InvalidFundingAmount = "Card:00001";
    public const string InvalidSpendingAmount = "Card:00002";
    public const string CardIsInActive = "Card:00003";
    public const string CardIsExpired = "Card:00004";
    public const string InsufficientFundingAmount = "Card:00005";
    public const string CardAlreadyActive = "Card:00006";
    public const string CardAlreadyInactive = "Card:00007";
}
