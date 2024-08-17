using System;

namespace MeuPrimeiroProjeto.Geladeira_Ex
{
    internal class Andar
    {
        // propriedades
        public List<Container> ContainerList { get; set; } = new List<Container>();

        public Andar()
        {
            // Inicializa com dois containers por padrão
            ContainerList.Add(new Container());
            ContainerList.Add(new Container());
        }


    }
}
