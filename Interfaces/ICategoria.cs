using BackendBG.Utilitarios;

namespace BackendBG.Interfaces
{
    public interface ICategoria
    {
        public Task<Result> GetCategorias(int id);
    }
}
