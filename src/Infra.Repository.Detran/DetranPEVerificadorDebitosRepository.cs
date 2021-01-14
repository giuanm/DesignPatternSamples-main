using DesignPatternSamples.Application.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranPEVerificadorRestricoesRepository : DetranVerificadorRestricoesRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranPEVerificadorRestricoesRepository(ILogger<DetranPEVerificadorRestricoesRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<RestricoesVeiculo>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Padronizando o Resultado {html}.");
            return Task.FromResult<IEnumerable<RestricoesVeiculo>>(new List<RestricoesVeiculo>() { new RestricoesVeiculo() { DataOcorrencia = DateTime.UtcNow } });
        }

        protected override Task<string> RealizarAcesso(Veiculo veiculo)
        {
            Task.Delay(5000).Wait(); //Deixando o serviço mais lento para evidenciar o uso do CACHE.
            _Logger.LogDebug($"Consultando Restrições do veículo placa {veiculo.Placa} para o estado de PE.");
            return Task.FromResult("CONTEUDO DO SITE DO DETRAN/PE");
        }
    }
}
