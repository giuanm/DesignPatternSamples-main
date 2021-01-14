using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using DesignPatternSamples.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Implementations
{
    public class DetranVerificadorRestricoesServices : IDetranVerificadorRestricoesService
    {
        private readonly IDetranVerificadorRestricoesFactory _Factory;

        public DetranVerificadorRestricoesServices(IDetranVerificadorRestricoesFactory factory)
        {
            _Factory = factory;
        }

        public Task<IEnumerable<RestricoesVeiculo>> ConsultarRestricoes(Veiculo veiculo)
        {
            IDetranVerificadorRestricoesRepository repository = _Factory.Create(veiculo.UF);
            return repository.ConsultarRestricoes(veiculo);
        }
    }
}
