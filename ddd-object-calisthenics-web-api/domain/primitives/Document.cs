namespace ddd_object_calisthenics_web_api.domain.primitives;

public sealed class Document
{
    public string Value { get; }

    public Document(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Documento não pode ser vazio.");

        value = value.Trim().Replace(".", "").Replace("-", "");

        if (!IsCpf(value))
            throw new ArgumentException("Documento (CPF) inválido.");

        Value = value;
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        return obj is Document other && Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();

    private static bool IsCpf(string cpf)
    {
        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        var numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        for (int j = 9; j < 11; j++)
        {
            var sum = 0;
            for (int i = 0; i < j; i++)
                sum += numbers[i] * (j + 1 - i);

            var remainder = sum % 11;
            var checkDigit = remainder < 2 ? 0 : 11 - remainder;

            if (numbers[j] != checkDigit)
                return false;
        }

        return true;
    }
}
