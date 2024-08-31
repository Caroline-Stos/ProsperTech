using System;
using System.Collections.Generic;

namespace RepositorioEntity.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public int? ContainerId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Container? Container { get; set; }
}
