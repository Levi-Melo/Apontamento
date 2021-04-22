using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento
{
    class Apontamento
    {
        public int idApontamento { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int numeroLote { get; set; }
        public int idEvento { get; set; }
        public int quantidade { get; set; }
    };
}
