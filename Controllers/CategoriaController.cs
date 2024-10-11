using BackendBG.Interfaces;
using BackendBG.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
    
    private readonly ICategoria _favorito;
    private LogError Log = new LogError();

    public CategoriaController(ICategoria categoria)
    {
        this._favorito = categoria;
    }
        [HttpGet]
    [Route("GetCategoria")]
    public async Task<Result> Getcategoria(int categoriaID)
    {
        var Result = new Result();
        try
        {
            Result = await _favorito.GetCategorias(categoriaID);
        }
        catch (Exception ex)
        {
            Log.LogErrorMetodos("CategoriaController", "Getcategoria", ex.Message);
        }
        return Result;
    }
}
}
