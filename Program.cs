using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Apontamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Object[] gapsInfo = CalculadorDeGaps.QuantidadesETempoDeGaps();

            List<Lotes> lotesDeProducao = CalculadorDeGaps.QuantidadesProduzidas();

            TimeSpan duracaoDeManutencao = CalculadorDeGaps.HorasDeManutencao();

        }
    }
}