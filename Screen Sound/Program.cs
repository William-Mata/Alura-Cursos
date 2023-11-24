// SCREEN SOUND
#region Variáveis 
List<string> bandas = new List<string>();
List<float> avaliacao = new List<float>();
List<int> quantidadeAvaliacao = new List<int>();
#endregion

#region Funções
ExibirMensagemDeBoasVindas();

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
    ExibirOpcoesDoMenu();
}

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");
    Console.Write("\nDigite a sua opção: ");

    string opcaoEscolhida = Console.ReadLine()!;
    ChamarOpcaoEscolhida(opcaoEscolhida);
}

void ChamarOpcaoEscolhida(string opcao)
{
    if (int.TryParse(opcao, out _))
    {
        switch (int.Parse(opcao))
        {
            case 0:
                break;
            case 1:
                RegistrarBanda(); break;
            case 2:
                MostrarTodasBandas(2); break;
            case 3:
                AvaliarBanda(); break;
            case 4:
                ExibirMediaAvaliacoesDaBanda(); break;
            default:
                Console.WriteLine("Opção Inválida."); ExibirOpcoesDoMenu(); break;
        }
    };
}

void RegistrarBanda()
{
    Console.WriteLine("\nVocê escolheu a opção de registrar banda");
    Console.Write("Digite o nome da banda: ");
    var nomeBanda = Console.ReadLine()!;
    bandas.Add(nomeBanda);
    avaliacao.Add(0);
    quantidadeAvaliacao.Add(0);
    ExibirOpcoesDoMenu();
}

void MostrarTodasBandas(int opcao)
{
    var posicao = 1;
    bandas.ForEach(x => Console.WriteLine((posicao++) + " - " + x));

    if(opcao == 2)
    {
        ExibirOpcoesDoMenu();
    }
}

void AvaliarBanda()
{
    MostrarTodasBandas(0);
    if(bandas.Count() > 0)
    {
        Console.Write("\nInforme o número da banda que deseja realizar a avalição: ");
        string posicao = Console.ReadLine()!;

        if(int.TryParse(posicao, out _) && bandas.Count() >= (int.Parse(posicao) - 1))
        {
            Console.Write("Digite a sua avaliação a banda "+ bandas[int.Parse(posicao) - 1] +": ");
            var avaliacaoBanda = Console.ReadLine()!;

            if(float.TryParse(avaliacaoBanda, out _)){
                avaliacao[((int.Parse(posicao) - 1))] += float.Parse(avaliacaoBanda);
                quantidadeAvaliacao[(int.Parse(posicao) - 1)]++;
            }
            Console.WriteLine();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("Avaliação inválida, repita o procedimento com uma avaliação válida.");
            AvaliarBanda();
        }
    }
    else
    {
        Console.WriteLine("Nenhuma banda foi cadastrada ainda.");
        ExibirOpcoesDoMenu();
    }
}

void ExibirMediaAvaliacoesDaBanda()
{
    MostrarTodasBandas(0);
    if (bandas.Count() > 0)
    {
        Console.Write("\nInforme o número da banda que deseja ver a média de avalição: ");
        string posicao = Console.ReadLine()!;

        if (int.TryParse(posicao, out _) && bandas.Count() >= (int.Parse(posicao) - 1))
        {
            int posicaoTratada = int.Parse(posicao) - 1;
            float mediaAvaliacaoBanda = avaliacao[posicaoTratada] / quantidadeAvaliacao[posicaoTratada]; 
            Console.WriteLine("A média de avaliação da banda " + bandas[posicaoTratada] + " é: " + mediaAvaliacaoBanda +"\n");
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine("Nenhuma banda foi cadastrada ainda.");
        ExibirOpcoesDoMenu();
    }
}
#endregion