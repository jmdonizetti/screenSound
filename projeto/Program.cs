// Screen Sound 
using System.Collections.Generic;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"U2", "ACDC", "METALICA"};
//Dictionary vai criar uma lista onde podemos registrar novas bandas assim como o código acima o List<String>ListaDasBandas, mas com esse novo código instanciamos uma nota, mas o código diz que temos um registro de bandas, mas ela não tem note ainda, será preciso criar uma função para dar nota.
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Cavaleiros do Forró", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda ");
    Console.WriteLine("Digite 2 para mostrar todas as bandas ");
    Console.WriteLine("Digite 3 para avaliar uma banda ");
    Console.WriteLine("Digite 4 para exibir a media de uma banda ");
    Console.WriteLine("Digite -1 para sair ");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("See you later! :) " + opcaoEscolhidaNumerica);
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }

}
//Código para registrar bandas 
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());//Esse código é para armazenar uma nova banda, ele foi criado como uma lista vazia, agora vamos criar uma função para dar notas.
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}
//Código para mostrar as bandas registradas!
void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    //Código for para complementar o código listaDasBandas.Add(nomeDaBanda); e adicionar e salvar na lista as bandas para ser exibido na função de MostrarBandasRegistradas();
    //for(int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    //Utilizando o foreach
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal!");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}
//Função para exibir o titulo das opções escolhidas e colocar os asteriscos entre o titulo
void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.WriteLine("Bandas que estão registradas:\n");
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.Write($"{banda}\n");
    }

    Console.Write("\nDigite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nQual nota a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.WriteLine("Bandas que estão registradas:\n");
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.Write($"{banda}\n");
    }

    Console.Write("\n\nDigite o nome da banda que deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.Write($"\nA nota da banda {nomeDaBanda} é: {notasDaBanda.Average()}!\n");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal!");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("\nEssa banda não foi encontrada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal!");
        Console.ReadKey(); 
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

ExibirOpcoesDoMenu();
