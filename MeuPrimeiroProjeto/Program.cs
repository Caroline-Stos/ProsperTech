using MeuPrimeiroProjeto.Geladeira_Ex;

// Aula 10 - Exercicio da geladeira Parte 2 - Feito por: Caroline de Lima Santos

// Geladeira Parte 2

// testando Container -----------------------------------------
// Container NovoContainer = new Container();
// NovoContainer.AddItem(0, "Maça");
// NovoContainer.ListarItens();
// NovoContainer.StatusContainer();
// NovoContainer.RemoverItem("Maça");
// NovoContainer.LimparContainer();

// testando Andar -----------------------------------------

//Andar HortiFruit =  new Andar();

//Console.WriteLine("Adicionando itens ao primeiro container:");
//HortiFruit.ContainerList[0].AddItem(0, "Maçã");
//HortiFruit.ContainerList[0].AddItem(1, "Laranja");
//HortiFruit.ContainerList[0].AddItem(2, "Melão");
//HortiFruit.ContainerList[0].AddItem(3, "Uva");

//HortiFruit.ContainerList[0].ListarItens();

// testando Geladeira -----------------------------------------

Geladeira_Poo minhaGeladeira = new Geladeira_Poo();

// Adicionando itens aos andares
minhaGeladeira.CarneAndar.ContainerList[0].AddItem(0, "Bife");
minhaGeladeira.CarneAndar.ContainerList[1].AddItem(0, "Frango");
minhaGeladeira.LaticAndar.ContainerList[0].AddItem(0, "Queijo");
minhaGeladeira.FruitAndar.ContainerList[0].AddItem(0, "Maçã");
minhaGeladeira.FruitAndar.ContainerList[1].AddItem(0, "Banana");

//minhaGeladeira.VerGeladeira();

minhaGeladeira.CarneAndar.ContainerList[0].ListarItens();
minhaGeladeira.LaticAndar.ContainerList[0].ListarItens();
minhaGeladeira.FruitAndar.ContainerList[0].ListarItens();
