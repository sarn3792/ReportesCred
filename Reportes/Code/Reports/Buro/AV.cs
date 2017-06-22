using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class AV
    {
        public DatoMoral identificadorSegmento = new DatoMoral("AV", "AV", 2);
        public DatoMoral RFC = new DatoMoral("00", 13);
        public DatoMoral CURP = new DatoMoral("01", 18);
        public DatoMoral reservado = new DatoMoral("02", String.Empty.PadRight(10, '0'), 10);
        public DatoMoral nombreCompania = new DatoMoral("03", 75);
        public DatoMoral primerNombre = new DatoMoral("04", 75);
        public DatoMoral segundoNombre = new DatoMoral("05", 75);
        public DatoMoral apellidoPaterno = new DatoMoral("06", 25);
        public DatoMoral apellidoMaterno = new DatoMoral("07", 25);
        public DatoMoral primeraLineaDireccion = new DatoMoral("08", 40);
        public DatoMoral segundaLineaDireccion = new DatoMoral("09", 40);
        public DatoMoral colonia = new DatoMoral("10", 60);
        public DatoMoral municipio = new DatoMoral("11", 40);
        public DatoMoral ciudad = new DatoMoral("12", 40);
        public DatoMoral nombreEstadoMexico = new DatoMoral("13", 4);
        public DatoMoral codigoPostal = new DatoMoral("14", 10);
        public DatoMoral numeroTelefono = new DatoMoral("15", 11);
        public DatoMoral extensionTelefonica = new DatoMoral("16", 8);
        public DatoMoral numeroFax = new DatoMoral("17", 11);
        public DatoMoral tipoAval = new DatoMoral("18", 1);
        public DatoMoral estadoExtranjero = new DatoMoral("19", 40);
        public DatoMoral pais = new DatoMoral("20", 2);
        public DatoMoral filler = new DatoMoral("21", String.Empty.PadRight(25, ' '), 25);

        public override string ToString()
        {
            try
            {
                String final = String.Empty;

                if (identificadorSegmento.Descripcion != String.Empty) final += String.Format("{0}", identificadorSegmento.ToString());
                if (RFC.Descripcion != String.Empty) final += String.Format("{0}", RFC.ToString());
                if (CURP.Descripcion != String.Empty) final += String.Format("{0}", CURP.ToString());
                if (reservado.Descripcion != String.Empty) final += String.Format("{0}", reservado.ToString());
                if (nombreCompania.Descripcion != String.Empty) final += String.Format("{0}", nombreCompania.ToString());
                if (primerNombre.Descripcion != String.Empty) final += String.Format("{0}", primerNombre.ToString());
                if (segundoNombre.Descripcion != String.Empty) final += String.Format("{0}", segundoNombre.ToString());
                if (apellidoPaterno.Descripcion != String.Empty) final += String.Format("{0}", apellidoPaterno.ToString());
                if (apellidoMaterno.Descripcion != String.Empty) final += String.Format("{0}", apellidoMaterno.ToString());
                if (primeraLineaDireccion.Descripcion != String.Empty) final += String.Format("{0}", primeraLineaDireccion.ToString());
                if (segundaLineaDireccion.Descripcion != String.Empty) final += String.Format("{0}", segundaLineaDireccion.ToString());
                if (colonia.Descripcion != String.Empty) final += String.Format("{0}", colonia.ToString());
                if (municipio.Descripcion != String.Empty) final += String.Format("{0}", municipio.ToString());
                if (ciudad.Descripcion != String.Empty) final += String.Format("{0}", ciudad.ToString());
                if (nombreEstadoMexico.Descripcion != String.Empty) final += String.Format("{0}", nombreEstadoMexico.ToString());
                if (codigoPostal.Descripcion != String.Empty) final += String.Format("{0}", codigoPostal.ToString());
                if (numeroTelefono.Descripcion != String.Empty) final += String.Format("{0}", numeroTelefono.ToString());
                if (extensionTelefonica.Descripcion != String.Empty) final += String.Format("{0}", extensionTelefonica.ToString());
                if (numeroFax.Descripcion != String.Empty) final += String.Format("{0}", numeroFax.ToString());
                if (tipoAval.Descripcion != String.Empty) final += String.Format("{0}", tipoAval.ToString());
                if (estadoExtranjero.Descripcion != String.Empty) final += String.Format("{0}", estadoExtranjero.ToString());
                if (pais.Descripcion != String.Empty) final += String.Format("{0}", pais.ToString());
                if (filler.Descripcion != String.Empty) final += String.Format("{0}", filler.ToString());

                return final;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}