using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reportes
{
    public class CR
    {
        public DatoMoral identificadorSegmento = new DatoMoral("CR", "CR", 2);
        public DatoMoral RFC = new DatoMoral("00", 13);
        public DatoMoral numeroExperienciasCrediticias = new DatoMoral("01", 6);
        public DatoMoral numeroCuenta = new DatoMoral("02", 25);
        public DatoMoral numeroCuentaAnterior = new DatoMoral("03", 25);
        public DatoMoral fechaAperturaCredito = new DatoMoral("04", 8);
        public DatoMoral plazo = new DatoMoral("05", 5);
        public DatoMoral tipoCredito = new DatoMoral("06", 4);
        public DatoMoral montoAutorizado = new DatoMoral("07", 20);
        public DatoMoral moneda = new DatoMoral("08", 3);
        public DatoMoral numeroPagos = new DatoMoral("09", 4);
        public DatoMoral frecuenciaPagos = new DatoMoral("10", 3);
        public DatoMoral importePago = new DatoMoral("11", 20);
        public DatoMoral fechaUltimoPago = new DatoMoral("12", 8);
        public DatoMoral fechaReestructura = new DatoMoral("13", 8);
        public DatoMoral pagoFinalCuentaMorosa = new DatoMoral("14", 20);
        public DatoMoral fechaLiquidacion = new DatoMoral("15", 8);
        public DatoMoral quita = new DatoMoral("16", 20);
        public DatoMoral dacionEnPago = new DatoMoral("17", 20);
        public DatoMoral quebranto = new DatoMoral("18", 20);
        public DatoMoral claveObservacion = new DatoMoral("19", 4);
        public DatoMoral marcaCreditoEspecial = new DatoMoral("20", 1);
        public DatoMoral fechaPrimerIncumplimiento = new DatoMoral("21", 8);
        public DatoMoral saldoInsolutoPrincipal = new DatoMoral("22", 20);
        public DatoMoral filler = new DatoMoral("23", String.Empty.PadRight(75, ' '), 75);

        public override string ToString()
        {
            try
            {
                String final = String.Empty;

                if (identificadorSegmento.Descripcion != String.Empty) final += String.Format("{0}", identificadorSegmento.ToString());
                if (RFC.Descripcion != String.Empty) final += String.Format("{0}", RFC.ToString());
                if (numeroExperienciasCrediticias.Descripcion != String.Empty) final += String.Format("{0}", numeroExperienciasCrediticias.ToString());
                if (numeroCuenta.Descripcion != String.Empty) final += String.Format("{0}", numeroCuenta.ToString());
                if (numeroCuentaAnterior.Descripcion != String.Empty) final += String.Format("{0}", numeroCuentaAnterior.ToString());
                if (fechaAperturaCredito.Descripcion != String.Empty) final += String.Format("{0}", fechaAperturaCredito.ToString());
                if (plazo.Descripcion != String.Empty) final += String.Format("{0}", plazo.ToString());
                if (tipoCredito.Descripcion != String.Empty) final += String.Format("{0}", tipoCredito.ToString());
                if (montoAutorizado.Descripcion != String.Empty) final += String.Format("{0}", montoAutorizado.ToString());
                if (moneda.Descripcion != String.Empty) final += String.Format("{0}", moneda.ToString());
                if (numeroPagos.Descripcion != String.Empty) final += String.Format("{0}", numeroPagos.ToString());
                if (frecuenciaPagos.Descripcion != String.Empty) final += String.Format("{0}", frecuenciaPagos.ToString());
                if (importePago.Descripcion != String.Empty) final += String.Format("{0}", importePago.ToString());
                if (fechaUltimoPago.Descripcion != String.Empty) final += String.Format("{0}", fechaUltimoPago.ToString());
                if (fechaReestructura.Descripcion != String.Empty) final += String.Format("{0}", fechaReestructura.ToString());
                if (pagoFinalCuentaMorosa.Descripcion != String.Empty) final += String.Format("{0}", pagoFinalCuentaMorosa.ToString());
                if (fechaLiquidacion.Descripcion != String.Empty) final += String.Format("{0}", fechaLiquidacion.ToString());
                if (quita.Descripcion != String.Empty) final += String.Format("{0}", quita.ToString());
                if (dacionEnPago.Descripcion != String.Empty) final += String.Format("{0}", dacionEnPago.ToString());
                if (quebranto.Descripcion != String.Empty) final += String.Format("{0}", quebranto.ToString());
                if (claveObservacion.Descripcion != String.Empty) final += String.Format("{0}", claveObservacion.ToString());
                if (marcaCreditoEspecial.Descripcion != String.Empty) final += String.Format("{0}", marcaCreditoEspecial.ToString());
                if (fechaPrimerIncumplimiento.Descripcion != String.Empty) final += String.Format("{0}", fechaPrimerIncumplimiento.ToString());
                if (saldoInsolutoPrincipal.Descripcion != String.Empty) final += String.Format("{0}", saldoInsolutoPrincipal.ToString());
                if (filler.Descripcion != String.Empty) final += String.Format("{0}", filler.ToString());

                return final;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}