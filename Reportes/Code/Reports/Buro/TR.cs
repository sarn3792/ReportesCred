using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class TR
    {
        private readonly String etiquetaSegmento = "TRLR";
        public String totalSaldosActuales = "12345678".PadLeft(14, '0');
        public String totalSaldosVencidos = "123".PadLeft(14, '0');
        public String totalSegmentosINTF = "1".PadLeft(3, '0');
        public String totalSegmentosPN = "2253".PadLeft(9, '0');
        public String totalSegmentosPA = "2253".PadLeft(9, '0');
        public String totalSegmentosPE = "0".PadLeft(9, '0');
        public String totalSegmentosTL = "2253".PadLeft(9, '0');
        public String contadorBloques = "0".PadLeft(6, '0');
        public String nombreUsuario = "CREDIJAL".PadRight(16, ' ');
        public String direccionUsuario = "AV. AMERICAS 1536 1B, COL. COUNTRY CLUB".PadRight(160, ' ');

        public override string ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", etiquetaSegmento, totalSaldosActuales, totalSaldosVencidos, totalSegmentosINTF, 
                totalSegmentosPN, totalSegmentosPA, totalSegmentosPE, totalSegmentosTL, contadorBloques, nombreUsuario, direccionUsuario);
        }
    }
}