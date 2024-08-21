using Animais_Exercicio;

// Instanciando novo felino
Felinos Gatinho = new();

// Atribuindo propriedades (Animal)
Console.WriteLine("\nPropriedades da base animal-----------------\n");
Gatinho.Nome = "Tom";
Console.WriteLine(Gatinho.Nome.ToString());

Gatinho.Especie = "Felino";
Console.WriteLine(Gatinho.Especie.ToString());

Gatinho.Raça = "Siamês";
Console.WriteLine(Gatinho.Raça.ToString());

// Atribuindo propriedades (Felino)
Console.WriteLine("\nPropriedades da base felino-----------------\n");
Gatinho.CorDoPelo = "Preto";
Console.WriteLine(Gatinho.CorDoPelo.ToString());

Gatinho.Tamanho = "Médio";
Console.WriteLine(Gatinho.Tamanho.ToString());

// Metodos do Felino
Console.WriteLine("\nMetodos da classe felino-----------------\n");
Gatinho.FazerBarulho();
Gatinho.Ronronar();

// Metodos da base
Console.WriteLine("\nMetodos da classe animal-----------------\n");
Gatinho.Cheirar();
Gatinho.Comer();
Gatinho.Dormir();
