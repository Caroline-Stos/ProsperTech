using Model.Geladeira;
using Microsoft.AspNetCore.Mvc;
using RepositorioEntity.Models;
using Servicos.Interfaces;

namespace GeladeiraAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        IService<ItemModel> _service;

        public GeladeiraController(IService<ItemModel> service)
        {
            _service = service;
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
