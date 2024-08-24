using MeuPrimeiroProjeto.Geladeira_Ex_P1;
using MeuPrimeiroProjeto.Geladeira_Ex_P2;

// Aula 5 - Exercicio da Geladeira Parte 1 - Feito por: Caroline de Lima Santos

// Exercicio da geladeira - Feito por: Caroline de Lima Santos
// Geladeira_P1.Main();

// Aula 10 - Exercicio da Geladeira Parte 2 - Feito por: Caroline de Lima Santos

Console.WriteLine("\nTestando Containers Isolado ------------------------------------------\n");

Container NovoContainer = new Container();

Console.WriteLine("\nAdicionando Novo Item: \n");

Console.WriteLine(NovoContainer.AddItem(0, "Maça"));
Console.WriteLine(NovoContainer.AddItem(1, "Uva"));

Console.WriteLine(NovoContainer.AddItem(2, "Mamao"));
Console.WriteLine(NovoContainer.AddItem(3, "Kiwi"));

Console.WriteLine("\nListando Item: \n");

Console.WriteLine(NovoContainer.ListarItens());

Console.WriteLine("\nVerificando o status do container: \n");

Console.WriteLine(NovoContainer.StatusContainer());

Console.WriteLine("\nRemovendo um Item: \n");

Console.WriteLine(NovoContainer.RemoverItem("Maça"));

Console.WriteLine("\nEsvaziando container: \n");

Console.WriteLine(NovoContainer.LimparContainer());




Console.WriteLine("\nTestando Andares Isolado ------------------------------------------\n");

Andar HortiFruit =  new Andar();

Console.WriteLine("\nAdicionando itens ao container 1 do andar HortiFruit: \n");

Console.WriteLine(HortiFruit.ContainerList[0].AddItem(0, "Maçã"));
Console.WriteLine(HortiFruit.ContainerList[0].AddItem(1, "Laranja"));

Console.WriteLine("\nAdicionando itens ao container 2 do andar HortiFruit: \n");

Console.WriteLine(HortiFruit.ContainerList[1].AddItem(2, "Melão"));
Console.WriteLine(HortiFruit.ContainerList[1].AddItem(3, "Uva"));

Console.WriteLine("\nListando os itens adicionados container 1: \n");
Console.WriteLine(HortiFruit.ContainerList[0].ListarItens());

Console.WriteLine("\nListando os itens adicionados container 2: \n");
Console.WriteLine(HortiFruit.ContainerList[1].ListarItens());


Console.WriteLine("\nTestando Geladeira ------------------------------------------\n");

Geladeira_P2 minhaGeladeira = new Geladeira_P2();

Console.WriteLine("\nAdicionando itens ao andar Carnes: \n");

// container 1
Console.WriteLine(minhaGeladeira.CarneAndar.ContainerList[0].AddItem(0, "Bife"));
Console.WriteLine(minhaGeladeira.CarneAndar.ContainerList[0].AddItem(1, "Linguiça"));

// container 2
Console.WriteLine(minhaGeladeira.CarneAndar.ContainerList[1].AddItem(0, "Frango"));
Console.WriteLine(minhaGeladeira.CarneAndar.ContainerList[1].AddItem(1, "Bacon"));

Console.WriteLine("\nAdicionando itens ao andar Laticinios: \n");

// container 1
Console.WriteLine(minhaGeladeira.LaticAndar.ContainerList[0].AddItem(0, "Queijo"));
Console.WriteLine(minhaGeladeira.LaticAndar.ContainerList[0].AddItem(1, "Iogurte"));

// container 2
Console.WriteLine(minhaGeladeira.LaticAndar.ContainerList[1].AddItem(0, "Leite fermentado"));
Console.WriteLine(minhaGeladeira.LaticAndar.ContainerList[1].AddItem(1, "Leite"));

Console.WriteLine("\nAdicionando itens ao andar Frutas: \n");

// container 1
Console.WriteLine(minhaGeladeira.FruitAndar.ContainerList[0].AddItem(0, "Maçã"));
Console.WriteLine(minhaGeladeira.FruitAndar.ContainerList[0].AddItem(1, "Banana"));

// container 2
Console.WriteLine(minhaGeladeira.FruitAndar.ContainerList[1].AddItem(0, "Limão"));
Console.WriteLine(minhaGeladeira.FruitAndar.ContainerList[1].AddItem(1, "Laranaj"));

Console.WriteLine("\nListando todos os itens na geladeira: \n");

minhaGeladeira.VerGeladeira();

Console.WriteLine("\nManipulando os itens adicionados: \n");

Console.WriteLine(minhaGeladeira.CarneAndar.ContainerList[0].ListarItens());

Console.WriteLine(minhaGeladeira.LaticAndar.ContainerList[0].RemoverItem("Leite"));

Console.WriteLine(minhaGeladeira.FruitAndar.ContainerList[0].StatusContainer());

Console.WriteLine(minhaGeladeira.FruitAndar.ContainerList[1].LimparContainer());


