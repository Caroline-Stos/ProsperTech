using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Geladeira
{
    public class ItemModel
    {
        // propriedades
        public int Id { get; set; }
        public string Nome { get; set; }

        // metodos
        public ItemModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
