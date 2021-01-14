using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranRJVerificadorRestricoesRepository : DetranVerificadorRestricoesRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranRJVerificadorRestricoesRepository(ILogger<DetranRJVerificadorRestricoesRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<RestricoesVeiculo>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<RestricoesVeiculo>>(new List<RestricoesVeiculo>() { new RestricoesVeiculo() });
        }

        protected override Task<string> RealizarAcesso(Veiculo veiculo)
        {
            _Logger.LogDebug($"Consultando restrições do veículo placa {veiculo.Placa} para o estado de RJ.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/RJ");
        }
    }
}
