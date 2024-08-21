
namespace Animais_Exercicio
{
    public class Felinos : Animal
    {
        // propriedades
        public string CorDoPelo { get; set; } = "";
        public string Tamanho { get; set; } = "";

        // metodos
        public override void FazerBarulho()
        {
            Console.WriteLine("Meeeooowwwww"); 
        }
        public void Ronronar()
        {
            Console.WriteLine("Ron Ron Ron");
        }
    }
}
