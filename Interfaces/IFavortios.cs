using BackendBG.Models;
using BackendBG.Utilitarios;

namespace BackendBG.Interfaces
{
    public interface IFavortios
    {
        public Task<Result> GetFavoritos();
        public Task<Result> PostFavoritos(Favorito favorito);
        public Task<Result> DeleteFavoritos(Favorito favorito);

    }
}
