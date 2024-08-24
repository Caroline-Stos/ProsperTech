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
        protected Geladeira_P2 MinhaGeladeira { get; set; }

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

        [HttpPost] // Rever metodo
        public string Post(string andar, int container, int posicao, Item item)
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
        public string Get()
        {
            return MinhaGeladeira.ListarItens();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            
        }

    }
}
