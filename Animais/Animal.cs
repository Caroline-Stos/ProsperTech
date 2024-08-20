

namespace Animais
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
        public virtual string FazerBarulho()
        {
            return "Roarrrrrrr";
        }
        public virtual string Cheirar()
        {
            return "Sniff sniff";
        }
        public virtual string Comer()
        {
            Boca = true;
            return "Comendo";
        }
        public virtual string Dormir()
        {
            Olhos = false;
            return "ZZZZZZZZZZZ";
        }
        public virtual string Correr()
        {
            return "Correndo";
        }
    }
}
}
