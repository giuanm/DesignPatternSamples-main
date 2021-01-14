using System;

namespace DesignPatternSamples.Application.Repository
{
    public interface IDetranVerificadorRestricoesFactory
    {
        public IDetranVerificadorRestricoesFactory Register(string UF, Type repository);
        public IDetranVerificadorRestricoesRepository Create(string UF);
    }
}
