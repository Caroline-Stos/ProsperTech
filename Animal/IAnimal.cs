
namespace Animais_Exercicio
{
    internal interface IAnimal
    {
        // propriedades
        public bool Olhos { get; set; }
        public bool Ouvidos { get; set; }
        public bool Nariz { get; set; }
        public bool Boca { get; set; }

        //metodos
        void FazerBarulho();
        void Cheirar();
        void Comer();
        void Dormir();
        void Correr();

    }
}
