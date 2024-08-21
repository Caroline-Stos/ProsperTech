
namespace Animais_Exercicio
{
    public class Animal : IAnimal
    {
        // propriedades
        public string Nome { get; set; } = "";
        public string Especie { get; set; } = "";
        public string Raça { get; set; } = "";

        public Animal()
        {
            Console.WriteLine("Animal criado.");
        }
        // métodos
        public virtual void FazerBarulho()
        {
            Console.WriteLine("Roarrrrrrr");
        }
        public virtual void Cheirar()
        {
            Console.WriteLine("Sniff sniff");
        }
        public virtual void Comer()
        {
            Console.WriteLine("Nhac Nhac Nhac");
        }
        public virtual void Dormir()
        {
            Console.WriteLine("ZZZZZZZZZZZ");
        }
    }
}
