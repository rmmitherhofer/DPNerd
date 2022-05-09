using DPNerd.Core.Utils;

namespace DPNerd.Core.DomainObjects.ValueObjects;

public class Cpf
{
    public const int CpfMaxLength = 11;
    public string Number { get; private set; }

    // Construtor Entity Framework
    protected Cpf() { }

    public Cpf(string number)
    {
        if (!IsValid(number)) throw new DomainException("CPF Inválido");
        Number = number.PadLeft(11, '0'); ;
    }

    public static bool IsValid(string cpf)
    {
        cpf = cpf.OnlyNumbers(cpf);

        int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digit;
        int sum;
        int remainder;
        cpf = cpf.PadLeft(11, '0');
        tempCpf = cpf.Substring(0, 9);
        sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;
        digit = remainder.ToString();
        tempCpf = tempCpf + digit;
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
        remainder = sum % 11;
        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;
        digit = digit + remainder.ToString();
        return cpf.EndsWith(digit);
    }
}
