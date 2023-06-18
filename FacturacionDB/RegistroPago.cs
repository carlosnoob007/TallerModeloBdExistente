using System;
using System.Collections.Generic;

namespace FacturacionDB;

public partial class RegistroPago
{
    public int PagoId { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? CantidadPagada { get; set; }

    public int? FacturaId { get; set; }

    public int? MetodoId { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual MetodosPago? Metodo { get; set; }
}
