using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

new Atendimento().AtendimentoCliente();

#region EXEMPLOS LIST
//Console.ReadKey();
//Console.Clear();
// A LIST RESTRINGE ADICIONAR SOMENTE INFORMAÇÕES DO TIPO QUE FOI DEFINIDO EM SUA DECLARAÇÃO List<TIPO>.
//List<ContaCorrente> listaDeContas1 = new List<ContaCorrente>();
//listaDeContas1.Add(new ContaCorrente(123, "456", 1000));
//listaDeContas1.Add(new ContaCorrente(321, "654", 1000));
//listaDeContas1.Add(new ContaCorrente(213, "546", 1000));
//listaDeContas1.Add(new ContaCorrente(312, "645", 1000));

//List<ContaCorrente> listaDeContas2 = new List<ContaCorrente>();
//listaDeContas2.Add(new ContaCorrente(123, "456", 1000));
//listaDeContas2.Add(new ContaCorrente(456, "654", 1000));
//listaDeContas2.Add(new ContaCorrente(789, "546", 1000));

//listaDeContas2.AddRange(listaDeContas); // ADICIONA TODOS OS ITENS DE UMA OUTRA LIST AO FINAL DA LIST.
//listaDeContas2.Reverse(); // INVERTE AS POSIÇÕES DOS ITENS DENTRO DA LIST
//Console.WriteLine("\n\n=== LISTA ADD RANGE / REVERSE  ===\n\n");
//listaDeContas2.ForEach(Console.WriteLine); // PERCORRE TODAS OS LITENS DA LIST

//var listaGetRange = listaDeContas2.GetRange(0, 1); // PEGA OS ITENS DA LISTA A PARTI DE UM INDEX ATÉ A QUANTIDADE INFORMADA (INDEX, QUANTIDADE).
//Console.WriteLine("\n\n=== LISTA GET RANGE ===\n\n");
//listaGetRange.ForEach(Console.WriteLine);

//listaGetRange.Clear(); // APAGA TODOS OS ITENS DA LISTA.
//Console.WriteLine("\n\n=== LISTA CLEAR ===\n\n");
//listaGetRange.ForEach(Console.WriteLine);


//List<string> nomesDosEscolhidos = new List<string>()
//{
//    "Bruce Wayne",
//    "Carlos Vilagran",
//    "Richard Grayson",
//    "Bob Kane",
//    "Will Farrel",
//    "Lois Lane",
//    "General Welling",
//    "Perla Letícia",
//    "Uxas",
//    "Diana Prince",
//    "Elisabeth Romanova",
//    "Anakin Wayne"
//};

//Console.WriteLine("\n\n=== ENCONTRA NOME NA LISTA ===\n\n"); 
//var nomeEncontrado = nomesDosEscolhidos.Find(x => x.Equals("Anakin Wayne")); // ENCONTRA UM ITEM ESPECIFICO NA LISTA E RETORNA O ITEM
//var nomeExiste = nomesDosEscolhidos.Contains("Anakin Wayne"); // ENCONTRA UM ITEM ESPECIFICO NA LISTA RETORNA SE EXISTE TRUE OU FALSE
//Console.WriteLine(nomeEncontrado);
//Console.WriteLine(nomeExiste);
#endregion

#region EXEMPLOS ARRAYLIST
//Console.ReadKey();
//Console.Clear();
/// O ArrayList PERMITE QUE ADICIONE QUAL QUER TIPO DE INFORMAÇÃO EM UM MESMO ArrayList, STRING, INT, OBJETOS, ETC.
//ArrayList listaDeContas = new ArrayList();
//listaDeContas.Add("TESTE");
//listaDeContas.Add(8);
//listaDeContas.Add(new object());
#endregion

#region EXEMPLOS SORTEDLIST
//Console.ReadKey();
//Console.Clear();
//Console.WriteLine("\n\n SORTEDLIST \n\n");
//SortedList<int, string> times = new SortedList<int, string>();
//times.Add(0, "Flamengo");
//times.Add(1, "Santos");
//times.Add(2, "Juventus");

//foreach (var item in times.Values)
//{
//    Console.WriteLine(item);
//}
#endregion

#region EXEMPLOS STACK (CONCEITO DE PILHA - LIFO LAST IN, FIRST OUT)
//Console.ReadKey();
//Console.Clear();
//Console.WriteLine("\n\n STACK \n\n");
//Stack<string> pilhaDeLivros = new Stack<string>();
//pilhaDeLivros.Push("Harry Porter e a Ordem da Fênix");
//pilhaDeLivros.Push("A Guerra do Velho.");
//pilhaDeLivros.Push("Protocolo Bluehand");
//pilhaDeLivros.Push("Crise nas Infinitas Terras.");

//var livro = pilhaDeLivros.Peek(); // PEGA O ITEM O ULTIMO ITEM DA LISTA/PILHA
//pilhaDeLivros.Pop(); // REMOVE O ITEM QUE ESTIVER NO TOPO DA PILHA
//Console.WriteLine($"{livro}\n");

//foreach (var item in pilhaDeLivros)
//{
//    Console.WriteLine(item);
//}
#endregion

#region EXEMPLOS QUEUE (CONCEITO DE FILA - FIFO FIRST IN, FIRST OUT)
//Console.ReadKey();
//Console.Clear();
//Console.WriteLine("\n\n QUEUE \n\n");

//Queue<string> filaAtendimento = new Queue<string>();
//filaAtendimento.Enqueue("André Silva");
//filaAtendimento.Enqueue("Lou Ferrigno");
//filaAtendimento.Enqueue("Gal Gadot");

//var atendimento = filaAtendimento.Peek(); // PEGA O ITEM O PRIMEIRO ITEM DA LISTA/FILA
//filaAtendimento.Dequeue(); // REMOVE O ITEM O PRIMEIRO ITEM DA LISTA/FILA

//foreach (var item in filaAtendimento)
//{
//    Console.WriteLine(item);
//}
#endregion

#region EXEMPLOS HASHSET
//Console.ReadKey();
//Console.Clear();
//Console.WriteLine("\n\n HASHSET \n\n");

//HashSet<int> numeros = new HashSet<int>(); // NÃO PERMITE ADICIONAR IFNORMAÇÕES DUPLICADAS AO LIST
//numeros.Add(0);
//numeros.Add(1);
//numeros.Add(1);
//numeros.Add(1);

//foreach (var item in numeros)
//{
//    Console.WriteLine(item);
//}
#endregion

#region EXEMPLOS ARRAYS
//Array amostras = Array.CreateInstance(typeof(double), 5);
//amostras.SetValue(5.9, 0);
//amostras.SetValue(1.8, 1);
//amostras.SetValue(7.1, 2);
//amostras.SetValue(10, 3);
//amostras.SetValue(6.9, 4);

//TesteArrayInt();
//TesteBuscarPalavra();
//TesteMediana(amostras);
//CalcularMedia(amostras);
//TesteArrayDeContasCorrente();

//void TesteArrayInt()
//{
//    int[] idades = new int[5];
//    idades[0] = 30;
//    idades[1] = 40;
//    idades[2] = 17;
//    idades[3] = 21;
//    idades[4] = 18;

//    Console.WriteLine($"\nTamanho do Array {idades.Length}");

//    int acumulador = 0;
//    for (int i = 0; i < idades.Length; i++)
//    {
//        int idade = idades[i];
//        Console.WriteLine($"índice [{i}] = {idade}");
//        acumulador += idade;
//    }

//    int media = acumulador / idades.Length;
//    Console.WriteLine($"Média de idades = {media}\n");
//}

//void TesteBuscarPalavra()
//{
//    string[] arrayDePalavras = new string[5];

//    for (int i = 0; i < arrayDePalavras.Length; i++)
//    {
//        Console.Write($"Digite {i + 1}ª Palavra: ");
//        arrayDePalavras[i] = Console.ReadLine()!;
//    }

//    Console.Write("Digite palavra a ser encontrada: ");
//    var busca = Console.ReadLine();

//    foreach (string palavra in arrayDePalavras)
//    {
//        if (palavra.Equals(busca))
//        {
//            Console.WriteLine($"\nPalavra encontrada = {busca}.\n");
//            break;
//        }
//    }
//}

//void TesteMediana(Array array)
//{
//    Console.WriteLine();

//    if (amostras.Length == 0)
//    {
//        Console.WriteLine("O array está vazio.");
//    }
//    else
//    {
//        double[] amostrasOrdenadas = (double[])array.Clone();
//        Array.Sort(amostrasOrdenadas);

//        int tamanho = amostrasOrdenadas.Length;
//        int meio = tamanho / 2;
//        double mediana = tamanho % 2 != 0 ? amostrasOrdenadas[meio] : (amostrasOrdenadas[meio] - amostrasOrdenadas[meio - 1]) / 2;

//        Console.WriteLine($"A mediana é: {mediana} ");
//    }
//}

//void CalcularMedia(Array array)
//{
//    Console.WriteLine();
    
//    if (amostras.Length == 0)
//    {
//        Console.WriteLine("O array está vazio.");
//    }
//    else
//    {
//        double somaDasAmostras = 0f;

//        foreach(var item in array)
//        {
//            somaDasAmostras += (double) item;
//        }

//        var media = somaDasAmostras / array.Length;

//        Console.WriteLine($"A média é: {media} ");
//    }
//}

//void TesteArrayDeContasCorrente()
//{
//    ListaDeContasCorrentes listaDeContasCorrentes = new ListaDeContasCorrentes();
//    var conta = new ContaCorrente(312, "456", 2000.00);
//    listaDeContasCorrentes.Adicionar(new ContaCorrente(123, "456", 800.00));
//    listaDeContasCorrentes.Adicionar(new ContaCorrente(789, "456", 700.00));
//    listaDeContasCorrentes.Adicionar(new ContaCorrente(456, "456", 900.00));
//    listaDeContasCorrentes.Adicionar(conta);
//    listaDeContasCorrentes.Adicionar(new ContaCorrente(789, "456", 1000.00));
//    listaDeContasCorrentes.Adicionar(new ContaCorrente(789, "456", 600.00));

//    listaDeContasCorrentes.ExibirContaComMaiorSaldo();
//    listaDeContasCorrentes.Remover(conta);
//    listaDeContasCorrentes.ExibirListasDeContas();
//    var contaRecuperada = listaDeContasCorrentes.RecuperarContaCorrentePorIndice(2);
//    Console.WriteLine(listaDeContasCorrentes[2]);
//}

//Generica<int> generica1 = new Generica<int>();
//generica1.ExibirInformacao(1);

//Generica<string> generica2 = new Generica<string>();
//generica2.ExibirInformacao("Teste"); 
#endregion