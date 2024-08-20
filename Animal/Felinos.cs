
namespace Animais_Exercicio
{
    public class Felinos : Animal
    {
        // propriedades
        protected bool Patinhas { get; set; }
        protected bool Rabo { get; set; }
        protected string CorPelos { get; set; }

        // metodos
        public Felinos(string corPelos)
        {
            Patinhas = true;
            Rabo = true;
            CorPelos = corPelos;
        }

        public override void FazerBarulho()
        {
            Console.WriteLine("Miauuuuuuu"); 
        }
        public void Ronronar()
        {
            Console.WriteLine("Ron Ron Ron");
        }
    }
}
