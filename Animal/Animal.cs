
using System.Threading.Channels;

namespace Animais_Exercicio
{
    public class Animal : IAnimal
    {
        public bool Olhos { get; set; }
        public bool Ouvidos { get; set; }
        public bool Nariz { get; set; }
        public bool Boca { get; set; }

        public Animal()
        {
            Olhos = true;
            Ouvidos = true;
            Nariz = true;
            Boca = true;
            Console.WriteLine("Animal criado.");
        }

        //métodos
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
            Boca = true;
            Console.WriteLine("Comendo");
        }
        public virtual void Dormir()
        {
            Olhos = false;
            Console.WriteLine("ZZZZZZZZZZZ"); 
        }
        public virtual void Correr()
        {
            Console.WriteLine("Correndo"); 
        }
    }
}
