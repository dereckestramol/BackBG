using BackendBG.Interfaces;
using BackendBG.Models;
using BackendBG.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private readonly IFavortios _favorito;
        private LogError Log = new LogError();

        public FavoritoController(IFavortios favorito)
        {
            this._favorito = favorito;
        }
        [HttpGet]
        [Route("GetFavorito")]
        public async Task<Result> GetFavorito()
        {
            var Result = new Result();
            try
            {
                Result = await _favorito.GetFavoritos();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FavoritoController", "GetFavorito", ex.Message);
            }
            return Result;
        }
        [HttpPost]
        [Route("PostFavorito")]
        public async Task<Result> PostFavorito([FromBody] Favorito favorito)
        {
            var Result = new Result();
            try
            {
                Result = await _favorito.PostFavortios(favorito);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FavoritoController", "PostFavorito", ex.Message);
            }
            return Result;
        }
        [HttpPost]
        [Route("DeleteFavorito")]
        public async Task<Result> DeleteFavorito([FromBody] Favorito favorito)
        {
            var Result = new Result();
            try
            {
                Result = await _favorito.DeleteFavortios(favorito);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("FavoritoController", "DeleteFavorito", ex.Message);
            }
            return Result;
        }
    }
}
