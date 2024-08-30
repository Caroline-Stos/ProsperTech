using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Geladeira
{
    public class Item
    {
        // propriedades
        public int Id { get; set; }
        public string Nome { get; set; }

        // metodos
        public Item(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
