using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class EM
    {
        public DatoMoral identificadorSegmento = new DatoMoral("EM", "EM", 2);
        public DatoMoral RFC = new DatoMoral("00", 13);
        public DatoMoral CURP = new DatoMoral("01", 18);
        public DatoMoral reservado = new DatoMoral("02", String.Empty.PadRight(10, '0'), 10);
        public DatoMoral nombreCompania = new DatoMoral("03", 75);
        public DatoMoral primerNombre = new DatoMoral("04", 75); 
        public DatoMoral segundoNombre = new DatoMoral("05", 75);
        public DatoMoral apellidoPaterno = new DatoMoral("06", 25);
        public DatoMoral apellidoMaterno = new DatoMoral("07", 25);
        public DatoMoral nacionalidad = new DatoMoral("08", 2);
        public DatoMoral calificacionCartera = new DatoMoral("09", 2);
        public DatoMoral actividadEconomica1 = new DatoMoral("10", 11);
        public DatoMoral actividadEconomica2 = new DatoMoral("11", 11);
        public DatoMoral actividadEconomica3 = new DatoMoral("12", 11);
        public DatoMoral primerLineaDireccion = new DatoMoral("13", 40);
        public DatoMoral segundaLineaDireccion = new DatoMoral("14", 40);
        public DatoMoral colonia = new DatoMoral("15", 60);
        public DatoMoral municipio = new DatoMoral("16", 40);
        public DatoMoral ciudad = new DatoMoral("17", 40);
        public DatoMoral nombreEstadoMexico = new DatoMoral("18", 4);
        public DatoMoral codigoPostal = new DatoMoral("19", 10);
        public DatoMoral numeroTelefono = new DatoMoral("20", 11);
        public DatoMoral extensionTelefonica = new DatoMoral("21", 8);
        public DatoMoral numeroFax = new DatoMoral("22", 11);
        public DatoMoral tipoCliente = new DatoMoral("23", 1);
        public DatoMoral nombreEstadoExtranjero = new DatoMoral("24", 40);
        public DatoMoral pais = new DatoMoral("25", 2);
        public DatoMoral claveConsolidacion = new DatoMoral("26", 8);
        public DatoMoral filler = new DatoMoral("27", 72);

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
                if (nacionalidad.Descripcion != String.Empty) final += String.Format("{0}", nacionalidad.ToString());
                if (calificacionCartera.Descripcion != String.Empty) final += String.Format("{0}", calificacionCartera.ToString());
                if (actividadEconomica1.Descripcion != String.Empty) final += String.Format("{0}", actividadEconomica1.ToString());
                if (actividadEconomica2.Descripcion != String.Empty) final += String.Format("{0}", actividadEconomica2.ToString());
                if (actividadEconomica3.Descripcion != String.Empty) final += String.Format("{0}", actividadEconomica3.ToString());
                if (primerLineaDireccion.Descripcion != String.Empty) final += String.Format("{0}", primerLineaDireccion.ToString());
                if (segundaLineaDireccion.Descripcion != String.Empty) final += String.Format("{0}", segundaLineaDireccion.ToString());
                if (colonia.Descripcion != String.Empty) final += String.Format("{0}", colonia.ToString());
                if (municipio.Descripcion != String.Empty) final += String.Format("{0}", municipio.ToString());
                if (ciudad.Descripcion != String.Empty) final += String.Format("{0}", ciudad.ToString());
                if (nombreEstadoMexico.Descripcion != String.Empty) final += String.Format("{0}", nombreEstadoMexico.ToString());
                if (codigoPostal.Descripcion != String.Empty) final += String.Format("{0}", codigoPostal.ToString());
                if (numeroTelefono.Descripcion != String.Empty) final += String.Format("{0}", numeroTelefono.ToString());
                if (extensionTelefonica.Descripcion != String.Empty) final += String.Format("{0}", extensionTelefonica.ToString());
                if (numeroFax.Descripcion != String.Empty) final += String.Format("{0}", numeroFax.ToString());
                if (tipoCliente.Descripcion != String.Empty) final += String.Format("{0}", tipoCliente.ToString());
                if (nombreEstadoExtranjero.Descripcion != String.Empty) final += String.Format("{0}", nombreEstadoExtranjero.ToString());
                if (pais.Descripcion != String.Empty) final += String.Format("{0}", pais.ToString());
                if (claveConsolidacion.Descripcion != String.Empty) final += String.Format("{0}", claveConsolidacion.ToString());
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