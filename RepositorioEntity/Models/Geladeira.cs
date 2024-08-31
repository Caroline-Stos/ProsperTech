using System;
using System.Collections.Generic;

namespace RepositorioEntity.Models;

public partial class Geladeira
{
    public int GeladeiraId { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public virtual ICollection<Andar> Andars { get; set; } = new List<Andar>();
}
