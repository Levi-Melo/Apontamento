using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento
{
    class CalculadorDeGaps
    {
        public static Object[] CalculoDeGaps()
        {
            Object[] gapsInfo;
            gapsInfo = new Object[2];

            List<Apontamento> apontamentos = LerApontamentos.lerApontamentos();
            
            TimeSpan allDiff = new TimeSpan();
            int quantidadeDeGaps = 0;


            for (int i = 0; i + 1 < apontamentos.Count; i++)
            {
                TimeSpan diff = apontamentos[i].dataFim.Subtract(apontamentos[i + 1].dataInicio);
                allDiff += diff;
                if (diff.TotalSeconds == 0)
                {
                    quantidadeDeGaps += 1;
                };
            }

            gapsInfo[0] = quantidadeDeGaps;
            gapsInfo[1] = allDiff;

            return gapsInfo;
        }
        
        public static void QuantidadesProduzidas()
        {
            List<Apontamento> apontamentos = LerApontamentos.lerApontamentos();
            int quantidadeTotal = 0;
            foreach(Apontamento apontamento in apontamentos){
                if (apontamento.idEvento == 1 | apontamento.idEvento == 2)
                {
                    quantidadeTotal += apontamento.quantidade;
                }
            }
        }

    }
}
