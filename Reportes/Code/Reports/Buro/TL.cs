using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class TL
    {
        public Dato nombreSegmento = new Dato("TL", "TL", 2);
        public Dato claveUsuario = new Dato("FF33890001", "01", 10);
        public Dato nombreUsuario = new Dato("CREDIJAL", "02", 16);
        public Dato numeroCuenta = new Dato("04", 25);
        public Dato tipoResponsabilidadCuenta = new Dato("05", 1);
        public Dato tipoCuenta = new Dato("06", 1);
        public Dato tipoContrato = new Dato("07", 2);
        public Dato monedaCredito = new Dato("08", 2);
        public Dato numeroPagos = new Dato("10", 4); //total mensualidades
        public Dato frecuenciaPagos = new Dato("11", 1);
        public Dato montoPagar = new Dato("12", 9);
        public Dato fechaAperturaCredito = new Dato("13", 8); //ddMMyyyy
        public Dato fechaUltimoPago = new Dato("14", 8);
        public Dato fechaUltimaDisposicion = new Dato("15", 8); //la misma que fechaUltimoPago
        public Dato fechaCierre = new Dato("16", 8);
        public Dato fechaReporteInformacion = new Dato("17", 8);
        public Dato creditoMaximoAutorizado = new Dato("21", 9);
        public Dato saldoActual = new Dato("22", 10);
        public Dato limiteCredito = new Dato("23", 9);
        public Dato saldoVencido = new Dato("24", 9);
        //public Dato numeroPagosVencidos = new Dato("25", 4);
        public Dato formaPagoActual = new Dato("26", 2);
        public Dato claveObservacion = new Dato("30", 2);
        public Dato fechaPrimerIncumplimiento = new Dato("43", 8);
        public Dato saldoInsoluto = new Dato("44", 10);
        public Dato montoUltimoPago = new Dato("45", 9);
        public Dato plazoEnMeses = new Dato("50", 6);
        public Dato montoCreditoOriginacion = new Dato("51", 9);
        public Dato finSegmentoTL = new Dato("FIN", "99", 3);

        public override string ToString()
        {
            String final = String.Empty;
            try
            {
                final = String.Format("{0}{1}{2}", nombreSegmento.ToString(), claveUsuario.ToString(), nombreUsuario.ToString());

                if (numeroCuenta.Descripcion != String.Empty) final += numeroCuenta.ToString();
                if (tipoResponsabilidadCuenta.Descripcion != String.Empty) final += tipoResponsabilidadCuenta.ToString();
                if (tipoCuenta.Descripcion != String.Empty) final += tipoCuenta.ToString();
                if (tipoContrato.Descripcion != String.Empty) final += tipoContrato.ToString();
                if (monedaCredito.Descripcion != String.Empty) final += monedaCredito.ToString();
                if (numeroPagos.Descripcion != String.Empty) final += numeroPagos.ToString();
                if (frecuenciaPagos.Descripcion != String.Empty) final += frecuenciaPagos.ToString();
                if (montoPagar.Descripcion != String.Empty) final += montoPagar.ToString();
                if (fechaAperturaCredito.Descripcion != String.Empty) final += fechaAperturaCredito.ToString();
                if (fechaUltimoPago.Descripcion != String.Empty) final += fechaUltimoPago.ToString();
                if (fechaUltimaDisposicion.Descripcion != String.Empty) final += fechaUltimaDisposicion.ToString();
                if (fechaCierre.Descripcion != String.Empty) final += fechaCierre.ToString();
                if (fechaReporteInformacion.Descripcion != String.Empty) final += fechaReporteInformacion.ToString();
                if (creditoMaximoAutorizado.Descripcion != String.Empty) final += creditoMaximoAutorizado.ToString();
                if (saldoActual.Descripcion != String.Empty) final += saldoActual.ToString();
                if (limiteCredito.Descripcion != String.Empty) final += limiteCredito.ToString();
                if (saldoVencido.Descripcion != String.Empty) final += saldoVencido.ToString();
                //if (numeroPagosVencidos.Descripcion != String.Empty) final += numeroPagosVencidos.ToString();
                if (formaPagoActual.Descripcion != String.Empty) final += formaPagoActual.ToString();
                if (claveObservacion.Descripcion != String.Empty) final += claveObservacion.ToString();
                if (fechaPrimerIncumplimiento.Descripcion != String.Empty) final += fechaPrimerIncumplimiento.ToString();
                if (saldoInsoluto.Descripcion != String.Empty) final += saldoInsoluto.ToString();
                if (montoUltimoPago.Descripcion != String.Empty) final += montoUltimoPago.ToString();
                if (plazoEnMeses.Descripcion != String.Empty) final += plazoEnMeses.ToString();
                if (montoCreditoOriginacion.Descripcion != String.Empty) final += montoCreditoOriginacion.ToString();

                final += finSegmentoTL.ToString();

            } catch (Exception ex)
            {
                throw ex;
            }
            /*
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}{20}{21}{22}", nombreSegmento.ToString(), claveUsuario.ToString(), 
                nombreUsuario.ToString(), numeroCuenta.ToString(), tipoResponsabilidadCuenta.ToString(), tipoCuenta.ToString(), tipoContrato.ToString(), monedaCredito.ToString(), 
                numeroPagos.ToString(), frecuenciaPagos.ToString(), montoPagar.ToString(), fechaAperturaCredito.ToString(), fechaUltimoPago.ToString(), fechaUltimaDisposicion.ToString(),
                creditoMaximoAutorizado.ToString(), saldoActual.ToString(), saldoVencido.ToString(), numeroPagosVencidos.ToString(), formaPagoActual.ToString(), 
                fechaPrimerIncumplimiento.ToString(), saldoInsoluto.ToString(), montoUltimoPago.ToString(), finSegmentoTL.ToString());
                */

            return final;
        }
    }
}