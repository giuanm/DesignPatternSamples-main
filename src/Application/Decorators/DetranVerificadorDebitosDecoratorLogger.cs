using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorRestricoesDecoratorLogger : IDetranVerificadorRestricoesService
    {
        private readonly IDetranVerificadorRestricoesService _Inner;
        private readonly ILogger<DetranVerificadorRestricoesDecoratorLogger> _Logger;

        public DetranVerificadorRestricoesDecoratorLogger(
            IDetranVerificadorRestricoesService inner,
            ILogger<DetranVerificadorRestricoesDecoratorLogger> logger)
        {
            _Inner = inner;
            _Logger = logger;
        }

        public async Task<IEnumerable<RestricoesVeiculo>> ConsultarRestricoes(Veiculo veiculo)
        {
            Stopwatch watch = Stopwatch.StartNew();
            _Logger.LogInformation($"Iniciando a execução do método ConsultarRestricoes({veiculo})");
            var result = await _Inner.ConsultarRestricoes(veiculo);
            watch.Stop(); 
            _Logger.LogInformation($"Encerrando a execução do método ConsultarRestricoes({veiculo}) {watch.ElapsedMilliseconds}ms");
            return result;
        }
    }
}