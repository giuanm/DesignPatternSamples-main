using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorRestricoesDecoratorCache : IDetranVerificadorRestricoesService
    {
        private readonly IDetranVerificadorRestricoesService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificadorRestricoesDecoratorCache(
            IDetranVerificadorRestricoesService inner,
            IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }

        public Task<IEnumerable<RestricoesVeiculo>> ConsultarRestricoes(Veiculo veiculo)
        {
            return Task.FromResult(_Cache.GetOrCreate($"{veiculo.UF}_{veiculo.Placa}", () => _Inner.ConsultarRestricoes(veiculo).Result));
        }
    }
}