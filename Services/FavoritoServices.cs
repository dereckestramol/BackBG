using BackendBG.DTOs;
using BackendBG.Models;
using BackendBG.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace BackendBG.Services
{
    public class FavoritoServices
    {
        private readonly DatabaseBgContext _context;
        private LogError log = new LogError();
        private DynamicEmpty dynamicEmpty = new DynamicEmpty();
        public FavoritoServices(DatabaseBgContext context)
        {
            this._context = context;
        }

        public async Task<Result> GetFavoritos()
        {
            var result = new Result();
            try
            {

                result.Data = await _context.Favoritos.Include(favorito=> favorito.IdCategoriaNavigation)
                    .Include(favorito=>favorito.IdProductoNavigation)
                    .Select(
                    favoritoDTO => new FavoritoDTO
                    {
                        IdFavorito=favoritoDTO.IdFavorito,
                        IdCategoria=favoritoDTO.IdCategoria,
                        IdProducto=favoritoDTO.IdProducto,  
                        descripCategoria=favoritoDTO.IdCategoriaNavigation.DescripCategoria ,
                        descripProducto=favoritoDTO.IdProductoNavigation.NameProducto  
                    }
                    ).ToListAsync();
                result.Code = dynamicEmpty.IsDynamicEmpty(result.Data) ? "204" : "200";
                result.Message = dynamicEmpty.IsDynamicEmpty(result.Data) ? $"No se encontro registro" : "Ok";
            }
            catch (Exception ex)
            {
                result.Code = "400";
                result.Message = "Se ha presentado un exception por favor comunicarse con sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetCategoria", ex.Message);
            }

            return result;
        }
        public async Task<Result> PostFavorito(Favorito Favorito)
        {
            var Result = new Result();
            try
            {

                _context.Favoritos.Add(Favorito);
                await _context.SaveChangesAsync();

                Result.Code = "000";
                Result.Message = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                Result.Code = "999";
                Result.Message = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                log.LogErrorMetodos("FavoritoService", "PostFavorito", ex.Message);
            }
            return Result;
        }
        public async Task<Result> DeleteFavorito(Favorito Favorito)
        {
            var Result = new Result();
            try
            {

                _context.Favoritos.Remove(Favorito);
                await _context.SaveChangesAsync();

                Result.Code = "000";
                Result.Message = "Se elimino correctamente";
            }
            catch (Exception ex)
            {
                Result.Code = "999";
                Result.Message = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                log.LogErrorMetodos("FavoritoService", "PostFavorito", ex.Message);
            }
            return Result;
        }
    }
}
