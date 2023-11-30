#region Variáveis
Dictionary<string, List<int>> vendasCarros = new Dictionary<string, List<int>> {
    { "Bugatti Veyron", new List<int> { 10, 15, 12, 8, 5 } },
    { "Koenigsegg Agera RS", new List<int> { 2, 3, 5, 6, 7 } },
    { "Lamborghini Aventador", new List<int> { 20, 18, 22, 24, 16 } },
    { "Pagani Huayra", new List<int> { 4, 5, 6, 5, 4 } },
    { "Ferrari LaFerrari", new List<int> { 7, 6, 5, 8, 10 } }
};
#endregion

#region Funções
void ImprimirTitulo()
{
    Console.WriteLine(@"
█▀▄▀█ █▀▀ █▀▄ █ ▄▀█   █▀▄ █▀▀   █░█ █▀▀ █▄░█ █▀▄ ▄▀█ █▀   █▀▄ █▀▀   █▀▀ ▄▀█ █▀█ █▀█ █▀█ █▀
█░▀░█ ██▄ █▄▀ █ █▀█   █▄▀ ██▄   ▀▄▀ ██▄ █░▀█ █▄▀ █▀█ ▄█   █▄▀ ██▄   █▄▄ █▀█ █▀▄ █▀▄ █▄█ ▄█");
    Console.WriteLine("\nSeja bem vindo(a) ao sistema de cálculo de média de vendas de carros");
}

void Menu()
{
    Console.Clear();
    ImprimirTitulo();
    Console.WriteLine("\nDigite 1 para listar os carro");
    Console.WriteLine("Digite 2 para calcular a média de vendas de carro");
    Console.Write("Digite a opção deseja: ");
    var opcao = Console.ReadLine()!;

    ChamarOpcao(opcao);
}

void ChamarOpcao(string opcao)
{
    Thread.Sleep(1000);
    Console.Clear();
    if (int.TryParse(opcao, out _))
    {
        switch (int.Parse(opcao))
        {
            case 1: FormatarTitulo("Carros Vendidos"); ListarCarrosVendidos(1); break;
            case 2: FormatarTitulo("Calculadora de Média de Vendas");CalcularMedia(); break;
            default: Console.WriteLine("Opção Inválida."); VoltarAoMenu(); break;
        }
    }
    else
    {
        Console.WriteLine("Opção Inválida.");
        VoltarAoMenu();
    }
}

void VoltarAoMenu()
{
    Console.WriteLine("\nDigite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Menu();
}

void CalcularMedia()
{
    ListarCarrosVendidos(0);
    Console.Write("\nInforme o nome do carro: ");
    var nomeDoCarro = Console.ReadLine()!;
    var carro = vendasCarros.ToList().Where(x => x.Key == nomeDoCarro).FirstOrDefault();

    if(carro.Key != null)
    {
        Console.WriteLine($"\nA média de venda do carro {nomeDoCarro} foi de: {carro.Value.Average()}");
        VoltarAoMenu();
    }
    else
    {
        Console.WriteLine($"O carro {nomeDoCarro} não foi encontrado.");
        VoltarAoMenu();
    }
}

void ListarCarrosVendidos(int opcao)
{  
    foreach (var item in vendasCarros.Keys)
    {
        Console.WriteLine(item);
    }

    if (opcao == 1)
    {
        VoltarAoMenu();
    }
}

void FormatarTitulo(string titulo)
{
    var estilo = new string('#', titulo.Length);
    Console.WriteLine($"{estilo}");
    Console.WriteLine($"{titulo}");
    Console.WriteLine($"{estilo}\n");
}

Menu();
#endregion