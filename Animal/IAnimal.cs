

namespace Animal
{
    internal interface IAnimal
    {
        // propriedades
        public bool Olhos { get; set; }
        public bool Ouvidos { get; set; }
        public bool Nariz { get; set; }
        public bool Boca { get; set; }

        //metodos
        string FazerBarulho();
        string Cheirar();
        string Comer();
        string Dormir();
        string Correr();

    }
}
