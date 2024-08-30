using Model.Geladeira_Ex_P1;
using Model.Geladeira_Ex_P2;

// Aula 5 - Exercicio da Geladeira Parte 1 - Feito por: Caroline de Lima Santos

// Exercicio da geladeira - Feito por: Caroline de Lima Santos
// Geladeira_P1.Main();

// Aula 10 - Exercicio da Geladeira Parte 2 - Feito por: Caroline de Lima Santos

Geladeira_P2 MinhaGeladeira = new Geladeira_P2();

Item novoItem = new Item(1, "Maça");

// parametros (Andar, container, posicao, item)
Console.WriteLine(MinhaGeladeira.AddItem("FruitAndar", 0, 0, novoItem));

Console.WriteLine(MinhaGeladeira.ListarItens());

// parametros (Andar, container, item)
Console.WriteLine(MinhaGeladeira.RemoverItem("FruitAndar", 0, novoItem));

Console.WriteLine(MinhaGeladeira.LimparContainer("FruitAndar", 0));

Console.WriteLine(MinhaGeladeira.StatusContainer("FruitAndar", 0));



