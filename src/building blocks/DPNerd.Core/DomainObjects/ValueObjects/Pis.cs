namespace DPNerd.Core.DomainObjects.ValueObjects;

public class Pis
{
    public string Number { get; private set; }

    protected Pis() { }
    public Pis(string number)
    {
        if(string.IsNullOrEmpty(number))
            throw new DomainException("Número do PIS não informado.");

        Number = number;
    }
}