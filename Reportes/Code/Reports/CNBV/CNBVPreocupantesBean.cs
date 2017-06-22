using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class CNBVPreocupantesBean
    {
        private String tipoReporte = "3";
        private String periodoReporte = String.Empty;
        private String folio = String.Empty;
        private String organoSupervisor = String.Empty;
        private String claveSujetoObligado = String.Empty;
        private String localidad = String.Empty;
        private String codigoPostal = String.Empty;
        private String tipoOperacion = String.Empty;
        private String instrumentoMonetario = String.Empty;
        private String numeroCuenta = String.Empty;
        private decimal monto = 0;
        private String moneda = String.Empty;
        private String fechaOperacion = String.Empty;
        private String fechaDeteccion = String.Empty;
        private String nacionalidad = String.Empty;
        private String tipoPersona = String.Empty;
        private String razonSocial = String.Empty;
        private String nombre = String.Empty;
        private String apellidoPaterno = String.Empty;
        private String apellidoMaterno = String.Empty;
        private String rfc = String.Empty;
        private String curp = String.Empty;
        private String fechaNacimiento = String.Empty;
        private String domicilio = String.Empty;
        private String colonia = String.Empty;
        private String ciudad = String.Empty;
        private String telefono = String.Empty;
        private String actividadEconomica = String.Empty;
        private String consecutivoCuentas = String.Empty;
        private String numeroCuentaC = String.Empty;
        private String claveSujetoObligadoC = String.Empty;
        private String nombreTitularCuenta = String.Empty;
        private String apellidoPaternoC = String.Empty;
        private String apellidoMaternoC = String.Empty;
        private String descripcionOperacion = String.Empty;
        private String razones = String.Empty;
        private bool operacionPrincipal;

        public CNBVPreocupantesBean(bool operacionPrincipal)
        {
            this.operacionPrincipal = operacionPrincipal;
        }

        public string TipoReporte
        {
            get
            {
                return tipoReporte;
            }
        }

        public string PeriodoReporte
        {
            get
            {
                return periodoReporte;
            }

            set
            {
                periodoReporte = value.Length > 8 ? value.Substring(0, 8).Trim().ToUpper() : value.Trim().ToUpper();
            }
        }

        public string Folio
        {
            get
            {
                return folio;
            }

            set
            {
                int number = Convert.ToInt32(value);
                folio = String.Format("{0:000000}", number);
            }
        }

        public string OrganoSupervisor
        {
            get
            {
                return organoSupervisor;
            }

            set
            {
                organoSupervisor = value.Length > 6 ? "0" + value.Substring(0, 5).Trim().ToUpper() : value.Trim().ToUpper();
            }
        }

        public string ClaveSujetoObligado
        {
            get
            {
                return claveSujetoObligado;
            }

            set
            {
                claveSujetoObligado = value.Length > 7 ? "0" + value.Substring(0, 6).Trim().ToUpper() : value.Trim().ToUpper();
            }
        }

        public string Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value.Length > 8 ? value.Substring(0, 8).Trim().ToUpper() : value.Trim().ToUpper();
            }
        }

        public string CodigoPostal
        {
            get
            {
                return codigoPostal;
            }

            set
            {
                codigoPostal = value.Length > 5 ? value.Substring(0, 5).Trim().ToUpper() : value.Trim().ToUpper();
            }
        }

        public string TipoOperacion
        {
            get
            {
                return tipoOperacion;
            }

            set
            {
                if (operacionPrincipal)
                    tipoOperacion = value.Length > 2 ? value.Substring(0, 2).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    tipoOperacion = "";
            }
        }

        public string InstrumentoMonetario
        {
            get
            {
                return instrumentoMonetario;
            }

            set
            {
                if (operacionPrincipal)
                    instrumentoMonetario = value.Length > 2 ? value.Substring(0, 2).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    instrumentoMonetario = "";
            }
        }

        public string NumeroCuenta
        {
            get
            {
                return numeroCuenta;
            }

            set
            {
                if (operacionPrincipal)
                    numeroCuenta = value.Length > 16 ? value.Substring(0, 16).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    numeroCuenta = "";
            }
        }

        public decimal Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public string Moneda
        {
            get
            {
                return moneda;
            }

            set
            {
                if (operacionPrincipal)
                    moneda = value.Length > 3 ? value.Substring(0, 3).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    moneda = "";
            }
        }

        public string FechaOperacion
        {
            get
            {
                return fechaOperacion;
            }

            set
            {
                if (operacionPrincipal)
                    fechaOperacion = value.Length > 8 ? value.Substring(0, 8).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    fechaOperacion = "";
            }
        }

        public string FechaDeteccion
        {
            get
            {
                return fechaDeteccion;
            }

            set
            {
                if (operacionPrincipal)
                    fechaDeteccion = value.Length > 8 ? value.Substring(0, 8).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    fechaDeteccion = "";
            }
        }

        public string Nacionalidad
        {
            get
            {
                return nacionalidad;
            }

            set
            {
                if (operacionPrincipal)
                {
                    //if (value.Equals("Mexicana", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    nacionalidad = "1";
                    //}
                    //else if (value.Equals("Extranjera", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    nacionalidad = "2";
                    //}
                    nacionalidad = value;
                }
                else
                {
                    nacionalidad = "";
                }
            }
        }

        public string TipoPersona
        {
            get
            {
                return tipoPersona;
            }

            set
            {
                if (operacionPrincipal)
                {
                    //if (value.Equals("Fisica", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    tipoPersona = "1";
                    //}
                    //else if (value.Equals("Moral", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    tipoPersona = "2";
                    //}
                    tipoPersona = value;
                }
                else
                {
                    tipoPersona = "";
                }
            }
        }

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                if (operacionPrincipal)
                    razonSocial = value.Length > 125 ? value.Substring(0, 125).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    razonSocial = "";
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                if (operacionPrincipal)
                    nombre = value.Length > 60 ? value.Substring(0, 60).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    nombre = "";
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return apellidoPaterno;
            }

            set
            {
                if (operacionPrincipal)
                    apellidoPaterno = value.Length > 60 ? value.Substring(0, 60).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    apellidoPaterno = "";
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return apellidoMaterno;
            }

            set
            {
                if (operacionPrincipal)
                    apellidoMaterno = value.Length > 30 ? value.Substring(0, 30).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    apellidoMaterno = "";

            }
        }

        public string RFC
        {
            get
            {
                return rfc;
            }

            set
            {
                if (operacionPrincipal)
                    rfc = value.Length > 13 ? value.Substring(0, 13).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    rfc = "";
            }
        }

        public string CURP
        {
            get
            {
                return curp;
            }

            set
            {
                if (operacionPrincipal)
                    curp = value.Length > 18 ? value.Substring(0, 18).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    curp = "";
            }
        }

        public string FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                if (operacionPrincipal)
                    fechaNacimiento = value.Length > 8 ? value.Substring(0, 8).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    fechaNacimiento = "";
            }
        }

        public string Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                if (operacionPrincipal)
                    domicilio = value.Length > 60 ? value.Substring(0, 60).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    domicilio = "";
            }
        }

        public string Colonia
        {
            get
            {
                return colonia;
            }

            set
            {
                if (operacionPrincipal)
                    colonia = value.Length > 30 ? value.Substring(0, 30).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    colonia = "";
            }
        }

        public string Ciudad
        {
            get
            {
                return ciudad;
            }

            set
            {
                if (operacionPrincipal)
                    ciudad = value.Length > 8 ? value.Substring(0, 8).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    ciudad = "";
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                if (operacionPrincipal)
                    telefono = value.Length > 40 ? value.Substring(0, 40).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    telefono = "";
            }
        }

        public string ActividadEconomica
        {
            get
            {
                return actividadEconomica;
            }

            set
            {
                if (operacionPrincipal)
                    actividadEconomica = value.Length > 7 ? value.Substring(0, 7).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    actividadEconomica = "";
            }
        }

        public string ConsecutivoCuentas
        {
            get
            {
                return consecutivoCuentas;
            }

            set
            {
                if (operacionPrincipal)
                {
                    if (nombre == "")
                    {
                        consecutivoCuentas = "";
                    }
                    else //Has a person
                    {
                        nombre = "00";
                    }
                }
                else
                {
                    int number = Convert.ToInt32(consecutivoCuentas);
                    consecutivoCuentas = String.Format("{0:0}", number);
                }
            }
        }

        public string NumeroCuentaC
        {
            get
            {
                return numeroCuentaC;
            }

            set
            {
                if (!operacionPrincipal)
                    numeroCuentaC = value.Length > 16 ? value.Substring(0, 16).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    numeroCuentaC = "";
            }
        }

        public string ClaveSujetoObligadoC
        {
            get
            {
                return claveSujetoObligadoC;
            }

            set
            {
                if (!operacionPrincipal)
                    claveSujetoObligadoC = value.Length > 7 ? value.Substring(0, 7).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    claveSujetoObligado = "";
            }
        }

        public string NombreTitularCuenta
        {
            get
            {
                return nombreTitularCuenta;
            }

            set
            {
                if (!operacionPrincipal)
                    nombreTitularCuenta = value.Length > 60 ? value.Substring(0, 60).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    nombreTitularCuenta = "";
            }
        }

        public string ApellidoPaternoC
        {
            get
            {
                return apellidoPaternoC;
            }

            set
            {
                if (!operacionPrincipal)
                    apellidoPaternoC = value.Length > 60 ? value.Substring(0, 60).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    apellidoPaternoC = "";
            }
        }

        public string ApellidoMaternoC
        {
            get
            {
                return apellidoMaternoC;
            }

            set
            {
                if (!operacionPrincipal)
                    apellidoMaternoC = value.Length > 30 ? value.Substring(0, 30).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    apellidoMaternoC = "";
            }
        }

        public string DescripcionOperacion
        {
            get
            {
                return descripcionOperacion;
            }

            set
            {
                if (operacionPrincipal)
                    descripcionOperacion = value.Length > 4000 ? value.Substring(0, 4000).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    descripcionOperacion = "";
            }
        }

        public string Razones
        {
            get
            {
                return razones;
            }

            set
            {
                if (operacionPrincipal)
                    razones = value.Length > 4000 ? value.Substring(0, 4000).Trim().ToUpper() : value.Trim().ToUpper();
                else
                    razones = "";
            }
        }

        public override string ToString()
        {
            String allData = String.Empty;
            try
            {
                allData = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10:0.00};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29};{30};{31};{32};{33};{34};{35}",
                                      TipoReporte, PeriodoReporte, Folio, OrganoSupervisor, ClaveSujetoObligado, Localidad, CodigoPostal, TipoOperacion, InstrumentoMonetario, NumeroCuenta, Monto, Moneda, FechaOperacion,
                                      FechaDeteccion, Nacionalidad, TipoPersona, RazonSocial, Nombre, ApellidoPaterno, ApellidoMaterno, RFC, CURP, FechaNacimiento, Domicilio, Colonia, Ciudad, Telefono, ActividadEconomica,
                                      ConsecutivoCuentas, NumeroCuentaC, ClaveSujetoObligadoC, NombreTitularCuenta, ApellidoPaternoC, ApellidoMaternoC, DescripcionOperacion, Razones);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return allData;
        }
    }
}