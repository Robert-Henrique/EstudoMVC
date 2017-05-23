using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Extensao
    {
        public static int ToInt32(this string texto)
        {
            int i;
            return Int32.TryParse(texto, out i) == true ? Convert.ToInt32(texto) : 0;
        }

        public static decimal ToDecimal(this string texto)
        {
            decimal i;
            return Decimal.TryParse(texto, out i) == true ? Convert.ToDecimal(texto) : 0;
        }

        public static string ToCurrency(this decimal? valor)
        {
            return string.Format("{0:#,##0.00}", valor ?? 0);
        }

        public static string ToDate(this DateTime dataHora)
        {
            return dataHora.ToDateTime(false);
        }

        public static string ToDateTime(this DateTime dataHora, bool formatarHora)
        {
            if (formatarHora)
                return string.Format("{0:dd/MM/yyyy HH:mm:ss}", dataHora);
            else
                return string.Format("{0:dd/MM/yyyy}", dataHora);
        }
    }
}
