namespace DPNerd.Core.Utils;

public static class StringUtils
{
    public static string OnlyNumbers(this string str, string input)
    {
        if (string.IsNullOrEmpty(str))        
            throw new ArgumentException($"'{nameof(str)}' não pode ser null ou vazia.", nameof(str));        

        return new string(input.Where(char.IsDigit).ToArray());
    }
}
