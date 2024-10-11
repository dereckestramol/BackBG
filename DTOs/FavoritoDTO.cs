using BackendBG.Models;

namespace BackendBG.DTOs
{
    public class FavoritoDTO
    {
        public int IdFavorito { get; set; }

        public int? IdProducto { get; set; }
        public string? descripProducto { get; set; }


        public int? IdCategoria { get; set; }
        public string? descripCategoria { get; set; }
        public double? precioProducto { get; set; }
        public string? imagenProducto {get; set;}

    }
}
