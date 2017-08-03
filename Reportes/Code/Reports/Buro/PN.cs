using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class PN
    {
        public Dato apellidoPaterno = new Dato("PN", 26);
        public Dato apellidoMaterno = new Dato("00", 26);
        public Dato apellidoAdicional = new Dato("01", 26);
        public Dato primerNombre = new Dato("02", 26);
        public Dato segundoNombre = new Dato("03", 26);
        public Dato fechaNacimiento = new Dato("04", 8);
        public Dato RFC = new Dato("05", 13);
        public Dato prefifoPersonal = new Dato("06", 4);
        public Dato nacionalidad = new Dato("08", 2);
        public Dato tipoResidencia = new Dato("09", 1);
        public Dato numeroLicenciaConducir = new Dato("10", 20);
        public Dato estadoCivil = new Dato("11", 1);
        public Dato sexo = new Dato("12", 1);
        public Dato numeroCedulaProfesional = new Dato("13", 20);
        public Dato numeroRegistroElectoral = new Dato("14", 20);
        public Dato CURP = new Dato("15", 20);
        public Dato clavePais = new Dato("16", 2);
        public Dato numeroDependientes = new Dato("17", 2);

        public override string ToString()
        {
            String final = String.Empty;
            try
            {
                if (apellidoPaterno.Descripcion != String.Empty) final = String.Format("{0}", apellidoPaterno.ToString());
                if (apellidoMaterno.Descripcion != String.Empty) final += String.Format("{0}", apellidoMaterno.ToString());
                if (apellidoAdicional.Descripcion != String.Empty) final += String.Format("{0}", apellidoAdicional.ToString());
                if (primerNombre.Descripcion != String.Empty) final += String.Format("{0}", primerNombre.ToString());
                if (segundoNombre.Descripcion != String.Empty)
                    final += String.Format("{0}", segundoNombre.ToString());
                else
                    final += String.Format("{0}{1}", segundoNombre.Etiqueta, "00");
                if (fechaNacimiento.Descripcion != String.Empty) final += String.Format("{0}", fechaNacimiento.ToString());
                if (RFC.Descripcion != String.Empty) final += String.Format("{0}", RFC.ToString());
                if (prefifoPersonal.Descripcion != String.Empty) final += String.Format("{0}", prefifoPersonal.ToString());
                if (nacionalidad.Descripcion != String.Empty) final += String.Format("{0}", nacionalidad.ToString());
                if (tipoResidencia.Descripcion != String.Empty) final += String.Format("{0}", tipoResidencia.ToString());
                if (numeroLicenciaConducir.Descripcion != String.Empty) final += String.Format("{0}", numeroLicenciaConducir.ToString());
                if (estadoCivil.Descripcion != String.Empty) final += String.Format("{0}", estadoCivil.ToString());
                if (sexo.Descripcion != String.Empty) final += String.Format("{0}", sexo.ToString());
                if (numeroCedulaProfesional.Descripcion != String.Empty) final += String.Format("{0}", numeroCedulaProfesional.ToString());
                if (numeroRegistroElectoral.Descripcion != String.Empty) final += String.Format("{0}", numeroRegistroElectoral.ToString());
                if (CURP.Descripcion != String.Empty) final += String.Format("{0}", CURP.ToString());
                if (clavePais.Descripcion != String.Empty) final += String.Format("{0}", clavePais.ToString());
                if (numeroDependientes.Descripcion != String.Empty) final += String.Format("{0}", numeroDependientes.ToString());
            } catch (Exception ex)
            {
                throw ex;
            }
            
            return final;
        }
    }
}