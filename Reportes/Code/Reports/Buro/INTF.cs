using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class INTF
    {
        private readonly String etiquetaSegmento = "INTF";
        public String version = "12";
        private readonly String claveUsuario = "FF33890001";
        private readonly String nombreUsuario = "CREDIJAL".PadRight(16, ' ');
        private readonly String reservado = "40";
        private readonly String fechaReporte = DateTime.Now.ToString("ddMMyyyy");
        private readonly String reservado2 = "0000000000";
        private readonly String informacionAdicional = String.Empty.PadRight(98, ' ');

        public override string ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}", etiquetaSegmento, version, claveUsuario, nombreUsuario, reservado, fechaReporte, reservado2, informacionAdicional);
        }
    }
}