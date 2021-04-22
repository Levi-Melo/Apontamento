using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Apontamento
{
    class LerApontamentos
    {
        private const string Path = @"..\..\..\data\data.csv";
        public static List<Apontamento> lerApontamentos() {
            StreamReader rd = new StreamReader(Path, Encoding.Default, true);

            string linha = null;
            string[] linhaseparada = null;
            List<Apontamento> apontamentos = new List<Apontamento>();

            // ler o conteudo da linha e add na list 
            while ((linha = rd.ReadLine()) != null)
            {
                linhaseparada = linha.Split(';');

                foreach (var item in linhaseparada)
                {
                    apontamentos.Add(new Apontamento()
                    {
                        idApontamento = int.Parse(linhaseparada[0]),
                        dataInicio = DateTime.Parse(linhaseparada[1]),
                        dataFim = DateTime.Parse(linhaseparada[2]),
                        numeroLote = int.Parse(string.IsNullOrEmpty(linhaseparada[3]) ? "0" : linhaseparada[3]),
                        idEvento = int.Parse(linhaseparada[4]),
                        quantidade = int.Parse(linhaseparada[5]),
                    });
                }
            }
            return apontamentos;
        }
    }
}       
