using System;
using System.Collections.Generic;

namespace FacturacionDB;

public partial class LineaFactura
{
    public int LineaFacturaId { get; set; }

    public int? Cantidad { get; set; }

    public string? Descripción { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? ImporteTotal { get; set; }

    public int? FacturaId { get; set; }

    public int? ProductoId { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual ProductoServicio? Producto { get; set; }
}
