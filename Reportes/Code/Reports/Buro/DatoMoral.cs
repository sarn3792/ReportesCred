using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class DatoMoral
    {
        private String etiqueta;
        private String descripcion;
        private int maximo;

        public string Etiqueta
        {
            get
            {
                return etiqueta;
            }

            set
            {
                etiqueta = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                if (value.Length > Maximo) //is invalid, truncate
                {
                    descripcion = value.Substring(0, Maximo);
                }
                else
                {
                    descripcion = value.PadRight(Maximo, ' ');
                }
            }
        }

        public int Maximo
        {
            get
            {
                return maximo;
            }

            set
            {
                maximo = value;
            }
        }

        public DatoMoral(String etiqueta, String descripcion, int maximo)
        {
            this.Maximo = maximo;
            this.Etiqueta = etiqueta;
            this.Descripcion = descripcion;
        }

        public DatoMoral(String etiqueta, int maximo)
        {
            this.Maximo = maximo;
            this.Etiqueta = etiqueta;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", Etiqueta, Descripcion);
        }
    }
}