using System;
using System.Collections.Generic;

namespace FacturacionDB;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Dirección { get; set; }

    public string? Teléfono { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
