using System;
using System.Collections.Generic;

namespace FacturacionDB;

public partial class Factura
{
    public int FacturaId { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? EstadoPago { get; set; }

    public decimal? ImporteTotal { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<LineaFactura> LineaFacturas { get; set; } = new List<LineaFactura>();

    public virtual ICollection<RegistroPago> RegistroPagos { get; set; } = new List<RegistroPago>();
}
