// SCREEN SOUND
#region Variáveis 
Dictionary<string, List<float>> bandas = new Dictionary<string, List<float>>();
#endregion

#region Métodos
void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║╚═╝
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██╗
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═╝");
    string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound!";
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    Console.Clear();
    ExibirMensagemDeBoasVindas();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");
    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;

    ChamarOpcaoEscolhida(opcaoEscolhida);
}

void VoltarAoMenu()
{
    Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu:");
    Console.ReadKey();
    ExibirOpcoesDoMenu();
}

void ChamarOpcaoEscolhida(string opcao)
{
    if (int.TryParse(opcao, out _))
    {
        Thread.Sleep(1000);
        Console.Clear();
        switch (int.Parse(opcao))
        {
            case 0:
                Console.WriteLine("Até Logo.");
                break;
            case 1:
                FormatarTitulo("| Registro de Banda |");
                RegistrarBanda(); 
                break;
            case 2:
                FormatarTitulo("| Mostrar Todas as Bandas |");
                MostrarTodasBandas(2); 
                break;
            case 3:
                FormatarTitulo("| Avaliar Banda |");
                AvaliarBanda();
                break;
            case 4:
                FormatarTitulo("| Exibir Média da Banda |");
                ExibirMediaAvaliacoesDaBanda(); 
                break;
            default:
                Console.WriteLine("Opção Inválida."); ExibirOpcoesDoMenu(); break;
        }
    };
}

void RegistrarBanda()
{
    Console.Write("\nDigite o nome da banda: ");
    var nomeDaBanda = Console.ReadLine()!;
    Console.WriteLine($"A banda \"{nomeDaBanda}\" foi cadastrada com sucesso!");
    bandas.Add(nomeDaBanda, new List<float>());
    VoltarAoMenu();
}

void MostrarTodasBandas(int opcao)
{
    var posicao = 1;
    var nomesDasBandas = bandas.Keys.ToList(); 
    nomesDasBandas.ForEach(x => Console.WriteLine((posicao++) + " - " + x));

    if (bandas.Count() == 0)
    {
        Console.WriteLine("Nenhuma banda foi cadastrada ainda.");
    }

    if (opcao == 2 || bandas.Count() == 0)
    {
        VoltarAoMenu();
    }
}

void AvaliarBanda()
{
    MostrarTodasBandas(0);

    Console.Write("\nInforme o nome da banda que deseja realizar a avalição: ");
    string nomeBanda = Console.ReadLine()!;
    var banda = bandas.ToList().Where(x => x.Key.ToUpper() == nomeBanda.ToUpper()).FirstOrDefault();

    if (banda.Key != null)
    {
        Console.Write($"Digite a sua avaliação a banda {banda.Key}: ");
        var avaliacaoBanda = Console.ReadLine()!;

        if(float.TryParse(avaliacaoBanda, out _)){
            banda.Value.Add(float.Parse(avaliacaoBanda));
            Console.WriteLine($"\nA nota {avaliacaoBanda} foi atribuida a banda {nomeBanda}");
        }

        VoltarAoMenu();
    }
    else
    {
        Console.WriteLine($"A banda \"{nomeBanda}\" não foi encontrado, repita o procedimento com a banda que já foi cadastrada.\n");
        
        Thread.Sleep(4000);
        ChamarOpcaoEscolhida("3");
    }
}

void ExibirMediaAvaliacoesDaBanda()
{
    MostrarTodasBandas(0);

    Console.Write("\nInforme o nome da banda que deseja ver a média de avalição: ");
    string nomeBanda = Console.ReadLine()!;
    var banda = bandas.ToList().Where(x => x.Key.ToUpper() == nomeBanda.ToUpper()).FirstOrDefault();

    if (banda.Key != null)
    {
        float mediaAvaliacaoBanda = banda.Value.Count() > 0 ? banda.Value.Average() : 0; 
        Console.WriteLine($"A média de avaliação da banda {banda.Key} é: {mediaAvaliacaoBanda}\n");

        VoltarAoMenu();
    }
    else
    {
        Console.WriteLine($"A banda \"{nomeBanda}\" não foi encontrada, repita o procedimento com a banda que já foi cadastrada.\n");
        
        Thread.Sleep(4000);
        ChamarOpcaoEscolhida("4");
    }
}

void FormatarTitulo(string titulo)
{
    var tracos = new string('-', titulo.Length);
    Console.WriteLine(tracos);
    Console.WriteLine(titulo);
    Console.WriteLine(tracos);
}

ExibirOpcoesDoMenu();
#endregion