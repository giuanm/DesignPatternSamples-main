using System;

namespace DesignPatternSamples.WebAPI.Models.Detran
{
    public class RestricoesVeiculoModel
    {
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public double Qtde { get; set; }
    }
}