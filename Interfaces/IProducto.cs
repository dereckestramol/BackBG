using BackendBG.Utilitarios;

namespace BackendBG.Interfaces
{
    public interface IProducto
    {
        public Task<Result> GetProductos();

    }
}
