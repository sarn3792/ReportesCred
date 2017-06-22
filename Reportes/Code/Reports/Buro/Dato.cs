using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class Dato
    {
        private String descripcion;
        private String etiqueta;
        private String tamano;
        private int tamanoMaximo;

        public Dato(String descripcion, String etiqueta, int tamanoMaximo)
        {
            this.tamanoMaximo = tamanoMaximo;
            this.Descripcion = descripcion;
            this.Etiqueta = etiqueta;
        }

        public Dato(String etiqueta, int tamanoMaximo)
        {
            this.tamanoMaximo = tamanoMaximo;
            this.Etiqueta = etiqueta;
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                if (value.Length > 9)
                {
                    Tamano = Convert.ToString(value.Length);
                }
                else
                {
                    Tamano = String.Format("0{0}", Convert.ToString(value.Length));
                }

                if (value.Length > tamanoMaximo) //is invalid, truncate
                {
                    descripcion = value.Substring(0, tamanoMaximo);
                    Tamano = tamanoMaximo.ToString().PadLeft(2, '0');
                }
                else 
                {
                    descripcion = value;
                }
            }
        }

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

        public string Tamano
        {
            get
            {
                return tamano;
            }

            set
            {
                tamano = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", Etiqueta, Tamano, Descripcion);
        }
    }
}