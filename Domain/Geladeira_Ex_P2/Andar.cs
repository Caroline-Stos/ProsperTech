﻿using System;

namespace Model.Geladeira_Ex_P2
{
    public class Andar
    {
        // propriedades
        public List<Container> ContainerList { get; set; } = new List<Container>();

        public Andar()
        {
            // Inicializa com dois containers por padrão p/ andar
            ContainerList.Add(new Container());
            ContainerList.Add(new Container());
        }

    }
}
