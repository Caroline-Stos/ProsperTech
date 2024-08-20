using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    internal class Gatinho : Animal
    {
        protected bool Patinhas {  get; set; }
        protected bool Rabo { get; set; }
        protected string CorPelos { get; set; }

        public Gatinho(string corPelos)
        {
            Patinhas = true;
            Rabo = true;
            CorPelos = corPelos;
        }

        public override string FazerBarulho()
        {
            return "Miauuuuuuu";
        }        
        public string Ronronar()
        {
            return "Ron Ron Ron";
        }
    }
}
