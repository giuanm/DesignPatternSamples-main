using DesignPatternSamples.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Services
{
    public interface IDetranVerificadorRestricoesService
    {
        Task<IEnumerable<RestricoesVeiculo>> ConsultarRestricoes(Veiculo veiculo);
    }
}
