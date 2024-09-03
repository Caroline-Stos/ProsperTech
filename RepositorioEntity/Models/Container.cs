using System;
using System.Collections.Generic;

namespace RepositorioEntity.Models;

public partial class Container
{
    public int ContainerId { get; set; }

    public int AndarId { get; set; }

    public string? NomeContainer { get; set; }

    public virtual Andar Andar { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Posicao> Posicaos { get; set; } = new List<Posicao>();
}
