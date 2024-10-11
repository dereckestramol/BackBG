namespace BackendBG.DTOs
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? NameProducto { get; set; }

        public double? Precio { get; set; }

        public string? DescripProducto { get; set; }

        public string? FotoProducto { get; set; }

        public int? IdCategoria { get; set; }
        public string? descripCategoria { get; set; }
    }
}
