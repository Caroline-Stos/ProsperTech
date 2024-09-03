using Model.Geladeira;
using Microsoft.AspNetCore.Mvc;
using RepositorioEntity.Context;
using RepositorioEntity.Models;
using Servicos;

namespace GeladeiraAPI.Controllers
{
    // Atividade - Aula 15: Geladeira API
    // Feito por: Adrielly Ribeiro da Silva, Aline dos Santos Araújo, Caroline de Lima Santos e Lillyan de Santana Rodrigues Teixeira

    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        GeladeiraDbContext _contexto;
        IConfiguration _configuration;
        GeladeiraService _service;

        public GeladeiraController(IConfiguration configuration, GeladeiraDbContext contexto)
        {
            _configuration = configuration;
            _contexto = contexto;
            _service = new GeladeiraService(_contexto, _configuration);
        }

        [HttpPost("AddItem")]  
        public ActionResult<string> Post(int container, int posicao, ItemModel itemModel)
        {
            try
            {
                return _service.AddNovoItem(container, posicao, itemModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarItens")] 
        public ActionResult<List<Item>> Get()
        {
            try
            {
                return _service.GetListarItens();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetItemById")] 
        public ActionResult<Item> Get(int id)
        {
            try
            {
                var item = _service.GetItemById(id);
                if (item != null)
                    return item;
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeletarItem")] 
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return _service.DeletarItem(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarNomeItem")] 
        public ActionResult<string> Put(ItemModel item)
        {
            try
            {
                return _service.AtualizarNomeItem(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EsvaziarContainer")] 
        public ActionResult<string> DeleteContainer(int containerId)
        {
            try
            {
                return _service.EsvaziarContainer(containerId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
