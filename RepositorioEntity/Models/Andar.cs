using System;
using System.Collections.Generic;

namespace RepositorioEntity.Models;

public partial class Andar
{
    public int AndarId { get; set; }

    public int GeladeiraId { get; set; }

    public string? NomeAndar { get; set; }

    public virtual ICollection<Container> Containers { get; set; } = new List<Container>();

    public virtual Geladeira Geladeira { get; set; } = null!;
}
