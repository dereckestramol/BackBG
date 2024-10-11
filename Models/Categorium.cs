using System;
using System.Collections.Generic;

namespace BackendBG.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? DescripCategoria { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
