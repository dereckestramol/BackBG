using BackendBG.Models;
using BackendBG.Utilitarios;

namespace BackendBG.Interfaces
{
    public interface IFavortios
    {
        public Task<Result> GetFavoritos();
        public Task<Result> PostFavortios(Favorito favorito);
        public Task<Result> DeleteFavortios(Favorito favorito);

    }
}
