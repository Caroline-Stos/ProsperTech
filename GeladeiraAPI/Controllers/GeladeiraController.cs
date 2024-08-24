using MeuPrimeiroProjeto.Geladeira_Ex_P2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        protected Geladeira_P2 MinhaGeladeira { get; set; }

        public GeladeiraController()
        {
            MinhaGeladeira = new Geladeira_P2();
            // adicionando itens na geladeira para testar metodo GET
            MinhaGeladeira.CarneAndar.ContainerList[0].AddItem(0, "Bacon");
            MinhaGeladeira.LaticAndar.ContainerList[0].AddItem(0, "Laranja");
            MinhaGeladeira.FruitAndar.ContainerList[0].AddItem(0, "Leite");
        }

        [HttpPost] // OK
        public string Post(string andar, int container, int posicao, string item)
        {
            try
            {
                if (andar == "CarneAndar")
                    return MinhaGeladeira.CarneAndar.ContainerList[container].AddItem(posicao, item);
                if (andar == "LaticAndar")
                    return MinhaGeladeira.LaticAndar.ContainerList[container].AddItem(posicao, item);
                if (andar == "FruitAndar")
                    return MinhaGeladeira.FruitAndar.ContainerList[container].AddItem(posicao, item);
                else { return "Andar invalido"; }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return ($"Error: {ex.Message}");
            }

        }
        [HttpGet] // OK 
        public List<string> Get()
        {
            return MinhaGeladeira.VerGeladeira();
        }

    }
}
