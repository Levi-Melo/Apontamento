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
            List<Apontamento> apontamentos = LerApontamentos.lerApontamentos();
            int quantidadeTotal = 0;
            foreach (Apontamento apontamento in apontamentos)
            {
                if (apontamento.idEvento == 1 |  apontamento.idEvento == 2)
                {
                    quantidadeTotal += apontamento.quantidade;
                }
            }
            Console.WriteLine(quantidadeTotal);
        }
    }
}