using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public abstract class DetranVerificadorRestricoesRepositoryCrawlerBase : IDetranVerificadorRestricoesRepository
    {
        public async Task<IEnumerable<RestricoesVeiculo>> ConsultarRestricoes(Veiculo veiculo)
        {
            var html = await RealizarAcesso(veiculo);
            return await PadronizarResultado(html);
        }

        protected abstract Task<string> RealizarAcesso(Veiculo veiculo);
        protected abstract Task<IEnumerable<RestricoesVeiculo>> PadronizarResultado(string html);
    }
}
