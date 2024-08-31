using System;
using System.Collections.Generic;

namespace RepositorioEntity.Models;

public partial class Container
{
    public int ContainerId { get; set; }

    public int? AndarId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Andar? Andar { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
