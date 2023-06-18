using System;
using System.Collections.Generic;

namespace FacturacionDB;

public partial class MetodosPago
{
    public int MetodoId { get; set; }

    public string? NombreMetodo { get; set; }

    public virtual ICollection<RegistroPago> RegistroPagos { get; set; } = new List<RegistroPago>();
}
