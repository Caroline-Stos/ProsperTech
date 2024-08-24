using MeuPrimeiroProjeto.Geladeira_Ex_P2;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")] // Ok
        public ActionResult<Item> Get(int id)
        {
            foreach (var andar in MinhaGeladeira.DictAndares.Values)
            {
                foreach (var container in andar.ContainerList)
                {
                    foreach (var item in container.ItensList)
                    {
                        if (item != null)
                        {
                            if (item.Id == id)
                                return Ok(item); // retorna o item encontrado
                        }
                    }
                }
            }

            return NotFound();
        }

        [HttpDelete("{id}")] // Ok
        public ActionResult<string> Delete(int id)
        {
            foreach (var andar in MinhaGeladeira.DictAndares.Values)
            {
                foreach (var container in andar.ContainerList)
                {
                    foreach (var item in container.ItensList)
                    {
                        if (item != null)
                        {
                            if (item.Id == id)
                                return container.RemoverItem(item); // remove o item encontrado
                        }
                    }
                }
            }

            return NotFound();
        }   
    }
}
