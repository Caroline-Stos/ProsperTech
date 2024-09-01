using System;

namespace Model.Geladeira
{
    public class AndarModel
    {
        // propriedades
        public List<ContainerModel> ContainerList { get; set; } = new List<ContainerModel>();

        public AndarModel()
        {
            // Inicializa com dois containers por padrão p/ andar
            ContainerList.Add(new ContainerModel());
            ContainerList.Add(new ContainerModel());
        }
    }
}
