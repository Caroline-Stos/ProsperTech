using Model.Geladeira;
using Microsoft.AspNetCore.Mvc;
using RepositorioEntity.Context;
using RepositorioEntity.Models;
using Servicos;
using Microsoft.Extensions.Configuration;

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

        [HttpPost("AddItem")] // OK 
        public ActionResult<string> Post(int container, int posicao, [FromBody] ItemModel item)
        {
            try
            {
                return _service.AddNovoItem(container, posicao, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarItens")] // Ok
        public ActionResult<List<ItemModel>> Get()
        {
            try
            {
                return _service.GetListaDeItem();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetItemById")] // Ok
        public ActionResult<Item> Get(int id)
        {
            try
            {
                return _service.GetItemById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            //[HttpPut("{id}")] // Ok
            //public ActionResult<ItemModel> Put(int id, [FromBody] ItemModel novoItem)
            //{
            //    foreach (var andar in MinhaGeladeira.DictAndares.Values)
            //    {
            //        foreach (var container in andar.ContainerList)
            //        {
            //            foreach (var item in container.ItensList)
            //            {
            //                if (item != null)
            //                {
            //                    if (item.Id == id)
            //                        item.Id = novoItem.Id;
            //                        item.Nome = novoItem.Nome;
            //                        return item; // Retorna o item atualizado
            //                }
            //            }
            //        }
            //    }

            //    return NotFound();

            //}

            //[HttpDelete("{id}")] // Ok
            //public ActionResult<string> Delete(int id)
            //{
            //    foreach (var andar in MinhaGeladeira.DictAndares.Values)
            //    {
            //        foreach (var container in andar.ContainerList)
            //        {
            //            foreach (var item in container.ItensList)
            //            {
            //                if (item != null)
            //                {
            //                    if (item.Id == id)
            //                        return container.RemoverItem(item); // Remove o item encontrado
            //                }
            //            }
            //        }
            //    }

            //    return NotFound();
            //}
        }
    }
