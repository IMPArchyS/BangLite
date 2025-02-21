internal static class UtilityHelpers
{

    public static int InputInt(string? input)
    {
        input = Console.ReadLine();
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        return -1;
    }
}