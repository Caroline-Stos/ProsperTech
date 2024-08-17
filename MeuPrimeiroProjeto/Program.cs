using MeuPrimeiroProjeto.Aula1_1;
using MeuPrimeiroProjeto.Aula1;
using MeuPrimeiroProjeto.Aula2;
using MeuPrimeiroProjeto.Aula_5;
using MeuPrimeiroProjeto.Geladeira_Ex;
using System.Text;

// Aula 1 - Conversor de temperatura;
// clsConvertTemp.Execute();

// Aula 1 - DateTime;
// clsDateTime.PrintDatas();

// Aula 2 - Arrays_Loops;
// clsArrays_Loops.TesteForEach

// Aula 3 - Condições;

// Aula 5 - Exercicio da geladeira - Feito por: Caroline de Lima Santos
// Geladeira.Main();

// Aula 6 - Versionamento GIT (teorico);

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
