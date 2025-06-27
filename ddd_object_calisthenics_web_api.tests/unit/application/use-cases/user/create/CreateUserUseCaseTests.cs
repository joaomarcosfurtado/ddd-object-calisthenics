using System.Threading.Tasks;
using Xunit;
using Moq;
using ddd_object_calisthenics_web_api.application.use_cases.user.create;
using ddd_object_calisthenics_web_api.domain.entities;
using ddd_object_calisthenics_web_api.domain.primitives;
using ddd_object_calisthenics_web_api.domain.repositories;
using ddd_object_calisthenics_web_api.application.use_cases;
using ddd_object_calisthenics_web_api.application.dtos;
using ddd_object_calisthenics_web_api.shared.exceptions;

namespace ddd_object_calisthenics_web_api.tests.unit.application.use_cases.user.create;

public class CreateUserUseCaseTests
{
    [Fact]
    public async Task Deve_criar_usuario_com_sucesso()
    {
        // Arrange
        var repositoryMock = new Mock<IUserRepository>();

        repositoryMock.Setup(r => r.Add(It.IsAny<User>()))
                      .Returns(Task.CompletedTask);

        var useCase = new CreateUserUseCase(repositoryMock.Object);

        var request = new CreateUserRequest
        {
            Email = "joao@example.com"
        };

        // Act
        var response = await useCase.Execute(request);

        // Assert
        Assert.NotNull(response);
        Assert.NotEqual(Guid.Empty, response.Id);

        repositoryMock.Verify(r => r.Add(It.Is<User>(u =>
            u.Email.ToString() == "joao@example.com"
        )), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData("invalido")]
    [InlineData("faltando@")]
    public async Task Deve_lancar_excecao_para_email_invalido(string emailInvalido)
    {
        var repositoryMock = new Mock<IUserRepository>();
        var useCase = new CreateUserUseCase(repositoryMock.Object);

        var request = new CreateUserRequest
        {
            Email = emailInvalido
        };

        await Assert.ThrowsAsync<BadRequestException>(() => useCase.Execute(request));
    }
}