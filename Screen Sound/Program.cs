// SCREEN SOUND
#region Variáveis 
List<string> bandas = new List<string>();
List<float> avaliacao = new List<float>();
List<int> quantidadeAvaliacao = new List<int>();
#endregion

#region Funções
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
                Console.WriteLine("---------------------");
                Console.WriteLine("| Registro de Banda |");
                Console.WriteLine("---------------------");
                RegistrarBanda(); 
                break;
            case 2:
                Console.WriteLine("---------------------------");
                Console.WriteLine("| Mostrar Todas as Bandas |");
                Console.WriteLine("---------------------------");
                MostrarTodasBandas(2); 
                break;
            case 3:
                Console.WriteLine("-----------------");
                Console.WriteLine("| Avaliar Banda |");
                Console.WriteLine("-----------------");

                AvaliarBanda();
                break;
            case 4:
                Console.WriteLine("-------------------------");
                Console.WriteLine("| Exibir Média da Banda |");
                Console.WriteLine("-------------------------");
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
    bandas.Add(nomeDaBanda);
    avaliacao.Add(0);
    quantidadeAvaliacao.Add(0);
    VoltarAoMenu();
}

void MostrarTodasBandas(int opcao)
{
    var posicao = 1;
    bandas.ForEach(x => Console.WriteLine((posicao++) + " - " + x));

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
    Console.Write("\nInforme o número da banda que deseja realizar a avalição: ");
    string posicao = Console.ReadLine()!;

    if(int.TryParse(posicao, out _) && bandas.Count() > (int.Parse(posicao) - 1))
    {
        Console.Write($"Digite a sua avaliação a banda {bandas[int.Parse(posicao) - 1]}: ");
        var avaliacaoBanda = Console.ReadLine()!;

        if(float.TryParse(avaliacaoBanda, out _)){
            avaliacao[((int.Parse(posicao) - 1))] += float.Parse(avaliacaoBanda);
            quantidadeAvaliacao[(int.Parse(posicao) - 1)]++;
        }
        VoltarAoMenu();
    }
    else
    {
        Console.WriteLine("Número da banda inválido, repita o procedimento com um número de banda válido.\n");
        AvaliarBanda();
    }
}

void ExibirMediaAvaliacoesDaBanda()
{
    MostrarTodasBandas(0);
    Console.Write("\nInforme o número da banda que deseja ver a média de avalição: ");
    string posicao = Console.ReadLine()!;

    if (int.TryParse(posicao, out _) && bandas.Count() > (int.Parse(posicao) - 1))
    {
        int posicaoTratada = int.Parse(posicao) - 1;
        float mediaAvaliacaoBanda = avaliacao[posicaoTratada] / quantidadeAvaliacao[posicaoTratada]; 
        Console.WriteLine($"A média de avaliação da banda {bandas[posicaoTratada]} é: {mediaAvaliacaoBanda}\n");
        VoltarAoMenu();
    }
    else
    {
        Console.WriteLine("Número da banda inválido, repita o procedimento com um número de banda válido.\n");
        ExibirMediaAvaliacoesDaBanda();
    }
}

ExibirOpcoesDoMenu();
#endregion