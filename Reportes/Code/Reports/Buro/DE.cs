using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class DE
    {
        public DatoMoral identificadorSegmento = new DatoMoral("DE", "DE", 2);
        public DatoMoral RFC = new DatoMoral("00", 13);
        public DatoMoral numeroCuenta = new DatoMoral("01", 25);
        public DatoMoral numeroDias = new DatoMoral("02", 3);
        public DatoMoral cantidad = new DatoMoral("03", 20);
        public DatoMoral filler = new DatoMoral("04", String.Empty.PadRight(75, ' '), 75);

        public override string ToString()
        {
            try
            {
                String final = String.Empty;

                if (identificadorSegmento.Descripcion != String.Empty) final += String.Format("{0}", identificadorSegmento.ToString());
                if (RFC.Descripcion != String.Empty) final += String.Format("{0}", RFC.ToString());
                if (numeroCuenta.Descripcion != String.Empty) final += String.Format("{0}", numeroCuenta.ToString());
                if (numeroDias.Descripcion != String.Empty) final += String.Format("{0}", numeroDias.ToString());
                if (cantidad.Descripcion != String.Empty) final += String.Format("{0}", cantidad.ToString());
                if (filler.Descripcion != String.Empty) final += String.Format("{0}", filler.ToString());

                return final;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}