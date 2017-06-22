using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class PA
    {
        public Dato direccion = new Dato("PA", 40);
        public Dato direccion2 = new Dato("00", 40);
        public Dato colonia = new Dato("01", 40);
        public Dato municipio = new Dato("02", 40);
        public Dato ciudad = new Dato("03", 40);
        public Dato estado = new Dato("04", 4);
        public Dato codigoPostal = new Dato("05", 5);
        public Dato numeroTelefono = new Dato("07", 11);

        public override string ToString()
        {
            String final = String.Empty;
            try
            {
                if (direccion.Descripcion != String.Empty) final = direccion.ToString();
                if (direccion2.Descripcion != String.Empty) final += direccion2.ToString();
                if (colonia.Descripcion != String.Empty) final += colonia.ToString();
                if (municipio.Descripcion != String.Empty) final += municipio.ToString();
                if (ciudad.Descripcion != String.Empty) final += ciudad.ToString();
                if (estado.Descripcion != String.Empty) final += estado.ToString();
                if (codigoPostal.Descripcion != String.Empty) final += codigoPostal.ToString();
                if (numeroTelefono.Descripcion != String.Empty) final += numeroTelefono.ToString();

                return final;

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}