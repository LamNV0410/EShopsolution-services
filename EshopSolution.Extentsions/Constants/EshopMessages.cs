namespace EshopSolution.Extensions.Constants
{
    public static class EshopMessages
    {
        public const string NOT_FOUND_MESSAGE = "{0} Not found";

        public static string GetMessage(string[] obj , string message)
        {
            return string.Format(message, obj);
        }
    }
}
