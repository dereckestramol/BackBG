using BackendBG.DTOs;
using BackendBG.Interfaces;
using BackendBG.Models;
using BackendBG.Scrutor;
using BackendBG.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace BackendBG.Services
{
    public class ProductoServices:IProducto, IServices<Producto>
    {
            private readonly DatabaseBgContext _context;
            private LogError log = new LogError();
            private DynamicEmpty dynamicEmpty = new DynamicEmpty();
            public ProductoServices(DatabaseBgContext context)
            {
                this._context = context;
            }

            public async Task<Result> GetProductos()
            {
                var result = new Result();
                try
                {

                    result.Data = await _context.Productos.Include(producto=>producto.IdCategoriaNavigation).Select(
                        productoDTO => new ProductoDTO
                        {
                            IdProducto=productoDTO.IdProducto,
                            NameProducto=productoDTO.NameProducto,
                            Precio=productoDTO.Precio,
                            DescripProducto=productoDTO.DescripProducto,
                            FotoProducto=productoDTO.FotoProducto,
                            IdCategoria=productoDTO.IdCategoria,
                            descripCategoria=productoDTO.IdCategoriaNavigation.DescripCategoria,
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
