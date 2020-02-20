using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secao04
{
    class ConversorMoeda
    {

        public static double IOF = 6.0;

        public static double DolarToReal(double dolarCotacao, double dolarComprado)
        {
            double total = dolarCotacao * dolarComprado;
            return total + IOF / 100 * total;
        }

    }
}
