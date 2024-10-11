using System;
using System.Collections.Generic;

namespace BackendBG.Models;

public partial class Favorito
{
    public int IdFavorito { get; set; }

    public int? IdProducto { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
