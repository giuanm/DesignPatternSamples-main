using System;

namespace DesignPatternSamples.Application.DTO
{
    [Serializable]
    public class RestricoesVeiculo
    {
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public double Qtde { get; set; }
    }
}