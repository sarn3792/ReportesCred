using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class TS
    {
        public DatoMoral identificadorSegmento = new DatoMoral("TS", "TS", 2);
        public DatoMoral numeroCompaniasReportadas = new DatoMoral("00", 7);
        public DatoMoral totalCantidad = new DatoMoral("01", 30);
        public DatoMoral filler = new DatoMoral("02", String.Empty.PadRight(53, ' '), 53);

        public override string ToString()
        {
            try
            {
                String final = String.Empty;

                if (identificadorSegmento.Descripcion != String.Empty) final += String.Format("{0}", identificadorSegmento.ToString());
                if (numeroCompaniasReportadas.Descripcion != String.Empty) final += String.Format("{0}", numeroCompaniasReportadas.ToString());
                if (totalCantidad.Descripcion != String.Empty) final += String.Format("{0}", totalCantidad.ToString());
                if (filler.Descripcion != String.Empty) final += String.Format("{0}", filler.ToString());

                return final;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}