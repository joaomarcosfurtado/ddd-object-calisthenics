using ddd_object_calisthenics_web_api.domain.primitives;
using ddd_object_calisthenics_web_api.shared.exceptions;

namespace ddd_object_calisthenics_web_api.tests.unit.domain.primitives;public class EmailTests
{
    [Theory]
    [InlineData("teste@example.com")]
    [InlineData("john.doe@domain.co")]
    [InlineData("user123@sub.domain.com")]
    public void Deve_criar_email_valido(string email)
    {
        var e = Email.Create(email);

        Assert.Equal(email, e);
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    [InlineData("invalido")]
    [InlineData("faltando@")]
    [InlineData("@semusuario.com")]
    public void Deve_lancar_excecao_para_email_invalido(string? invalido)
    {
        Assert.Throws<BadRequestException>(() => Email.Create(invalido!));
    }

    [Fact]
    public void Dois_emails_com_mesmo_valor_devem_ser_iguais()
    {
        var email1 = Email.Create("user@example.com");

        var email2 = Email.Create("user@example.com");

        Assert.Equal(email1, email2);
        Assert.True(email1.Equals(email2));
        Assert.Equal(email1.GetHashCode(), email2.GetHashCode());
    }

    [Fact]
    public void Emails_diferentes_devem_ser_diferentes()
    {
        var email1 = Email.Create("a@example.com");
        var email2 = Email.Create("b@example.com");

        Assert.NotEqual(email1, email2);
        Assert.False(email1.Equals(email2));
    }
}