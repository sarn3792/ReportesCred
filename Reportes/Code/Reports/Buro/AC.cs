using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class AC
    {
        public DatoMoral identificadorSegmento = new DatoMoral("AC", "AC", 2);
        public DatoMoral RFCAccionista = new DatoMoral("00", 13);
        public DatoMoral CURP = new DatoMoral("01", 18);
        public DatoMoral campoReservado = new DatoMoral("02", String.Empty.PadRight(10, '0'), 10);
        public DatoMoral nombreCompaniaAccionista = new DatoMoral("03", 75);
        public DatoMoral primerNombreAccionista = new DatoMoral("04", 75);
        public DatoMoral segundoNombreAccionista = new DatoMoral("05", 75);
        public DatoMoral apellidoPaternoAccionista = new DatoMoral("06", 25);
        public DatoMoral apellidoMaternoAccionista = new DatoMoral("07", 25);
        public DatoMoral porcentajeAccionista = new DatoMoral("08", 2);
        public DatoMoral primeraLineaDireccion = new DatoMoral("09", 40);
        public DatoMoral segundaLineaDireccion = new DatoMoral("10", 40);
        public DatoMoral colonia = new DatoMoral("11", 60);
        public DatoMoral municipio = new DatoMoral("12", 40);
        public DatoMoral ciudad = new DatoMoral("13", 40);
        public DatoMoral nombreEstadoMexico = new DatoMoral("14", 4);
        public DatoMoral codigoPostal = new DatoMoral("15", 10);
        public DatoMoral numeroTelefono = new DatoMoral("16", 11);
        public DatoMoral extensionTelefonica = new DatoMoral("17", 8);
        public DatoMoral numeroFax = new DatoMoral("18", 11);
        public DatoMoral tipoAccionista = new DatoMoral("19", 1);
        public DatoMoral estadoExtranjero = new DatoMoral("20", 40);
        public DatoMoral pais = new DatoMoral("21", 2);
        public DatoMoral filler = new DatoMoral("22", String.Empty.PadRight(25, ' '), 25);

        public override string ToString()
        {
            try
            {
                String final = String.Empty;

                if (identificadorSegmento.Descripcion != String.Empty) final += String.Format("{0}", identificadorSegmento.ToString());
                if (RFCAccionista.Descripcion != String.Empty) final += String.Format("{0}", RFCAccionista.ToString());
                if (CURP.Descripcion != String.Empty) final += String.Format("{0}", CURP.ToString());
                if (campoReservado.Descripcion != String.Empty) final += String.Format("{0}", campoReservado.ToString());
                if (nombreCompaniaAccionista.Descripcion != String.Empty) final += String.Format("{0}", nombreCompaniaAccionista.ToString());
                if (primerNombreAccionista.Descripcion != String.Empty) final += String.Format("{0}", primerNombreAccionista.ToString());
                if (segundoNombreAccionista.Descripcion != String.Empty) final += String.Format("{0}", segundoNombreAccionista.ToString());
                if (apellidoPaternoAccionista.Descripcion != String.Empty) final += String.Format("{0}", apellidoPaternoAccionista.ToString());
                if (apellidoMaternoAccionista.Descripcion != String.Empty) final += String.Format("{0}", apellidoMaternoAccionista.ToString());
                if (porcentajeAccionista.Descripcion != String.Empty) final += String.Format("{0}", porcentajeAccionista.ToString());
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
                if (tipoAccionista.Descripcion != String.Empty) final += String.Format("{0}", tipoAccionista.ToString());
                if (estadoExtranjero.Descripcion != String.Empty) final += String.Format("{0}", estadoExtranjero.ToString());
                if (pais.Descripcion != String.Empty) final += String.Format("{0}", pais.ToString());
                if (filler.Descripcion != String.Empty) final += String.Format("{0}", filler.ToString());

                return final;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}