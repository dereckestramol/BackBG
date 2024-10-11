using BackendBG.DTOs;
using BackendBG.Interfaces;
using BackendBG.Models;
using BackendBG.Scrutor;
using BackendBG.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace BackendBG.Services
{
    public class CategoriaServices:ICategoria, IServices<Categorium>
    {
        private readonly DatabaseBgContext _context;
        private LogError log = new LogError();
        private DynamicEmpty dynamicEmpty = new DynamicEmpty();
        public CategoriaServices(DatabaseBgContext context)
        {
            this._context = context;
        }

        public async Task<Result> GetCategorias()
        {
            var result = new Result();
            try
            {

                result.Data = await _context.Categoria.Select(
                    categoriaDTO => new CategoriaDTO
                    {
                        IdCategoria=categoriaDTO.IdCategoria,   
                        DescripCategoria=categoriaDTO.DescripCategoria,
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

}
}
