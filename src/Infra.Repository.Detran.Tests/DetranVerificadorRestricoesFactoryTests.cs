using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Infra.Repository.Detran;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DesignPatternsSamples.Infra.Repository.Detran.Tests
{
    public class DetranVerificadorRestricoesFactoryTests : IClassFixture<DependencyInjectionFixture>
    {
        private readonly IDetranVerificadorRestricoesFactory _Factory;

        public DetranVerificadorRestricoesFactoryTests(DependencyInjectionFixture dependencyInjectionFixture)
        {
            var serviceProvider = dependencyInjectionFixture.ServiceProvider;
            _Factory = serviceProvider.GetService<IDetranVerificadorRestricoesFactory>();
        }

        [Theory(DisplayName = "Dado um UF que está devidamente registrado no Factory devemos receber a sua implementação correspondente")]
        [InlineData("PE", typeof(DetranPEVerificadorRestricoesRepository))]
        [InlineData("RJ", typeof(DetranRJVerificadorRestricoesRepository))]
        public void InstanciarServicoPorUFRegistrado(string uf, Type implementacao)
        {
            var resultado = _Factory.Create(uf);

            Assert.NotNull(resultado);
            Assert.IsType(implementacao, resultado);
        }

        [Fact(DisplayName = "Dado um UF que não está registrado no Factory devemos receber NULL")]
        public void InstanciarServicoPorUFNaoRegistrado()
        {
            IDetranVerificadorRestricoesRepository implementacao = _Factory.Create("CE");

            Assert.Null(implementacao);
        }
    }
}
