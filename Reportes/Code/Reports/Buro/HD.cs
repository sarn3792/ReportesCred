using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class HD
    {
        public DatoMoral identificadorSegmento = new DatoMoral("HD", "BNCPM", 5);
        public DatoMoral claveUsuario = new DatoMoral("00", "3389", 4);
        public DatoMoral claveUsuarioAnterior = new DatoMoral("01", "0000", 4);
        public DatoMoral tipoUsuario = new DatoMoral("02", "005", 3);
        public DatoMoral tipoFormato = new DatoMoral("03", "1", 1);
        public DatoMoral fechaReporteInformacion = new DatoMoral("04", DateTime.Now.ToString("ddMMyyyy"), 8);
        public DatoMoral periodo = new DatoMoral("05", 6);
        public DatoMoral version = new DatoMoral("06", "03", 2);
        public DatoMoral filler = new DatoMoral("07", String.Empty.PadRight(49, ' '), 49);

        public override string ToString()
        {
            try
            {
                return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", identificadorSegmento.ToString(), claveUsuario.ToString(), claveUsuarioAnterior.ToString(), tipoUsuario.ToString(),
                                                                tipoFormato.ToString(), fechaReporteInformacion.ToString(), periodo.ToString(), version.ToString(), filler.ToString());
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}