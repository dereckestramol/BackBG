using System;
using System.Collections.Generic;

namespace BackendBG.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NameProducto { get; set; }

    public double? Precio { get; set; }

    public string? DescripProducto { get; set; }

    public string? FotoProducto { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }
}
