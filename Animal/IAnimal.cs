
namespace Animais_Exercicio
{
    internal interface IAnimal
    {
        // propriedades
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raça  { get; set; }

        //metodos
        void FazerBarulho();
        void Cheirar();
        void Comer();
        void Dormir();
    }
}
