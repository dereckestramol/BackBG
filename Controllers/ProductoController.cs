using BackendBG.Interfaces;
using BackendBG.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _favorito;
        private LogError Log = new LogError();

        public ProductoController(IProducto producto)
        {
            this._favorito = producto;
        }
        [HttpGet]
        [Route("GetProducto")]
        public async Task<Result> GetProducto()
        {
            var Result = new Result();
            try
            {
                Result = await _favorito.GetProductos();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProdcutoController", "GetProducto", ex.Message);
            }
            return Result;
        }
    }
}
