using iTextSharp.xmp.options;
using MeuPrimeiroProjeto.Geladeira_Ex_P2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection;

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        private Geladeira_P2 MinhaGeladeira { get; set; }

        public GeladeiraController()
        {
            MinhaGeladeira = new Geladeira_P2();

            // criando novos itens
            Item novoItem = new(0, "Maça"); // ID + Nome
            Item novoItem2 = new(1, "Bacon");
            Item novoItem3 = new(2, "Leite");

            // adicionando itens na geladeira para testar metodo GET
            MinhaGeladeira.AddItem("FruitAndar", 0, 0, novoItem);
            MinhaGeladeira.AddItem("CarneAndar", 0, 0, novoItem2);
            MinhaGeladeira.AddItem("LaticAndar", 0, 0, novoItem3);

        }

        [HttpPost] // OK
        public string Post(string andar, int container, int posicao, Item item)
        {
            return MinhaGeladeira.AddItem(andar, container, posicao, item);
        }

        [HttpGet] // OK 
        public string Get()
        {
            return MinhaGeladeira.ListarItens();
        }

        [HttpGet("{id}")] // Rever
        public ActionResult<Item> Get(int id)
        {
            foreach (var andar in MinhaGeladeira.DictAndares.Values)
            {
                foreach (var container in andar.ContainerList)
                {

                    var item = container.ItensList.FirstOrDefault(item => item.Id == id);

                    if (item != null)
                    {
                        return Ok(item); // Retorna o item encontrado
                    }
                }
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            foreach (var andar in MinhaGeladeira.DictAndares.Values)
            {
                foreach (var container in andar.ContainerList)
                {
                    var item = container.ItensList.FirstOrDefault(item => item.Id == id);

                    if (item != null)
                    {
                        return container.RemoverItem(item); // Retorna o item encontrado
                    }
                }
            }

            return NotFound();
        }   
    }
}
