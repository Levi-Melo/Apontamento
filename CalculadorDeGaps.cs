using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Apontamento
{
    class CalculadorDeGaps
    {
        public static Object[] QuantidadesETempoDeGaps()
        {
            Object[] gapsInfo;
            gapsInfo = new Object[2];

            List<Apontamento> apontamentos = LerApontamentos.lerApontamentos();
            
            TimeSpan allDiff = new TimeSpan();
            int quantidadeDeGaps = 0;


            for (int i = 0; i + 1 < apontamentos.Count; i++)
            {
                TimeSpan diff = apontamentos[i].dataFim.Subtract(apontamentos[i + 1].dataInicio);
                if (diff != TimeSpan.Zero)
                {
                    allDiff += diff;
                    quantidadeDeGaps += 1;
                };
            }

            gapsInfo[0] = quantidadeDeGaps;
            gapsInfo[1] = allDiff;

            Console.WriteLine("Total duração de gaps em dias, horas, minutos e segundo :" + gapsInfo[1]);
            Console.WriteLine("Total quantidade :" + gapsInfo[0]);

            return gapsInfo;
        }
        
        public static List<Lotes> QuantidadesProduzidas()
        {
            List<Apontamento> apontamentos = LerApontamentos.lerApontamentos();

            int loteAnterior = 0;
            List<int> quatidadePorLote = new List<int>();
            int quantidadeSomadaTotal = 0;

            List<Lotes> lotes = new List<Lotes>();

            foreach (var apontamento in GetApontamentosDeProducao(apontamentos))
            {
                if (loteAnterior == apontamento.numeroLote)
                {
                    quantidadeSomadaTotal += apontamento.quantidade;
                }
                else
                {
                    lotes.Add(new Lotes()
                    {
                        numeroLote = loteAnterior,
                        quantidadeProduzida = quantidadeSomadaTotal,
                    });
                    loteAnterior = apontamento.numeroLote;
                    quantidadeSomadaTotal = 0;
                }
            }
            List<Lotes> lotesOrdenado = new List<Lotes>(LotesOrdenados(lotes));

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i + 1 + "° lote mais produtivo " + lotesOrdenado[i].numeroLote +
                    " produziu um total de " + lotesOrdenado[i].quantidadeProduzida);
            }
            return lotesOrdenado;
        }

        public static TimeSpan HorasDeManutencao()
        {
            List<Apontamento> apontamentos = LerApontamentos.lerApontamentos();
            TimeSpan allDiff = new TimeSpan();

            foreach (Apontamento apontamento in apontamentos)
            {
                if (apontamento.idEvento == 19)
                {
                    allDiff += apontamento.dataFim.Subtract(apontamento.dataInicio);
                }
            };
            int dias = allDiff.Days * 24;
            int horas = allDiff.Hours + dias;
            int minutos = allDiff.Minutes;
            int segundos = allDiff.Seconds;
            String timespanSemDias = horas + ":" + minutos + ":" + segundos;
            Console.WriteLine("Período Total De Manutenção em horas, minutos e segundos : " + timespanSemDias);

            return allDiff;
        }

        private static IEnumerable<Apontamento> GetApontamentosDeProducao(List<Apontamento> apontamentos)
        {
            return from Apontamento apontamento in apontamentos
                   orderby apontamento.numeroLote
                   where apontamento.idEvento == 1 | apontamento.idEvento == 2
                   select apontamento;
        }

        private static IEnumerable<Lotes> LotesOrdenados(List<Lotes> lotes)
        {
            return from Lotes lote in lotes
                   orderby lote.quantidadeProduzida descending
                   select lote;
        }

    }
}
