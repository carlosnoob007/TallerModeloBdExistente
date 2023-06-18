using System;
using System.Collections.Generic;

namespace FacturacionDB;

public partial class ProductoServicio
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public decimal? PrecioUnit { get; set; }

    public virtual ICollection<LineaFactura> LineaFacturas { get; set; } = new List<LineaFactura>();
}
