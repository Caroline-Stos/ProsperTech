using System;
using System.Collections.Generic;

namespace RepositorioEntity.Models;

public partial class Posicao
{
    public int PosicaoId { get; set; }

    public int? ContainerId { get; set; }

    public string? NomePosicao { get; set; }

    public virtual Container? Container { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
