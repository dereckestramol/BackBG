using BackendBG.Models;

namespace BackendBG.DTOs
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        public string? DescripCategoria { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
