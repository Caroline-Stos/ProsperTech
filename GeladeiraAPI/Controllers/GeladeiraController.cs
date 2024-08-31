using Model.Geladeira;
using Microsoft.AspNetCore.Mvc;

namespace GeladeiraAPI.Controllers
{
    // Atividade - Aula 15: Geladeira API
    // Feito por: Adrielly Ribeiro da Silva, Aline dos Santos Araújo, Caroline de Lima Santos e Lillyan de Santana Rodrigues Teixeira

    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        private Geladeira_P2 MinhaGeladeira { get; set; }

        public GeladeiraController()
        {
            MinhaGeladeira = new Geladeira_P2();

            // criando novos itens
            Item novoItem = new(1, "Maça"); 
            Item novoItem2 = new(2, "Bacon");
            Item novoItem3 = new(3, "Leite");

            // adicionando itens na geladeira para testar metodo GET
            MinhaGeladeira.AddItem("FruitAndar", 0, 0, novoItem);
            MinhaGeladeira.AddItem("CarneAndar", 0, 0, novoItem2);
            MinhaGeladeira.AddItem("LaticAndar", 0, 0, novoItem3);

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
                                return item; // retorna o item encontrado
                        }
                    }
                }
            }

            return NotFound();
        }

        [HttpPost] // Os nomes dos andares válidos são: CarneAndar, LaticAndar e FruitAndar
        public string Post(string andar, int container, int posicao, Item novoItem)
        {
            return MinhaGeladeira.AddItem(andar, container, posicao, novoItem);
        }

        [HttpPut("{id}")] // Ok
        public ActionResult<Item> Put(int id, [FromBody] Item novoItem)
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
                                item.Id = novoItem.Id;
                                item.Nome = novoItem.Nome;
                                return item; // Retorna o item atualizado
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
                                return container.RemoverItem(item); // Remove o item encontrado
                        }
                    }
                }
            }

            return NotFound();
        }
    }
}
