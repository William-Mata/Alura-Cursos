using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento;

public class Atendimento
{
    List<ContaCorrente> listaDeContas = new List<ContaCorrente>() { 
    new ContaCorrente(97, "123456-X", 1100) { Titular = new Cliente { Cpf = "11111", Nome = "William" } },
    new ContaCorrente(97, "345678-X", 1200) { Titular = new Cliente { Cpf = "22222", Nome = "Maria" } }};

    public void AtendimentoCliente()
    {
        try
        {
            char opcao = '0';
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("############################");
                Console.WriteLine("###     Atendimento      ###");
                Console.WriteLine("### 1 - Cadastrar Conta  ###");
                Console.WriteLine("### 2 - Listar Contas    ###");
                Console.WriteLine("### 3 - Remover Conta    ###");
                Console.WriteLine("### 4 - Ordenar Contas   ###");
                Console.WriteLine("### 5 - Pesquisar Conta  ###");
                Console.WriteLine("### 6 - Sair do Sistema  ###");
                Console.WriteLine("###########################");
                Console.WriteLine("\n");
                Console.Write("Digite a opção desejada: ");

                try
                {
                    opcao = Console.ReadLine()![0];
                }
                catch (Exception excecao)
                {
                    throw new ByteBankExceptions(excecao.Message);
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoveConta();
                        break;
                    case '4':
                        OrdernarContas();
                        break;
                    case '5':
                        PesquisarConta();
                        break;
                    case '6':
                        SairDoSistema();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }
        catch (ByteBankExceptions ex) // UTILIZANDO UMA CLASS PARA TRATAMENTO DE EXCEÇÕES
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void SairDoSistema()
    {
        Console.WriteLine($"Sistema encerrado com sucesso!");
        Console.ReadKey();
        
    }

    private void PesquisarConta()
    {
        Console.Clear();
        Console.WriteLine("#########################");
        Console.WriteLine("### PESQUISA DE CONTA ###");
        Console.WriteLine("#########################\n");

        Console.WriteLine("1 - Para pesquisar por Nome");
        Console.WriteLine("2 - Para pesquisar por CPF");
        Console.WriteLine("3 - Para pesquisar por Número Da Conta");
        Console.WriteLine("4 - Para pesquisar por Número Da Agência");
        Console.Write("Informe a opção: ");
        var opcao = Console.ReadLine();
        ContaCorrente conta = null;

        switch (opcao)
        {
            case "1": conta = PesquisarContaPorNumeroDaAgencia(); break;
            case "2": conta = PesquisarContaPorCPF(); break;
            case "3": conta = PesquisarContaPorNumeroDaConta(); break;
            case "4": conta = PesquisarContaPorNumeroDaAgencia(); break;
            default: Console.WriteLine("\nOpção Inválida."); break;
        }

        if (conta != null)
        {
            Console.WriteLine(conta);
        }

        Console.ReadKey();
    }

    private ContaCorrente PesquisarContaPorNumeroDaAgencia()
    {
        try
        {
            Console.Write("\nInforme o Número da Agência: ");
            var numeroAgencia = int.Parse(Console.ReadLine()!);

            return (from conta in listaDeContas
                    where conta.Numero_agencia == numeroAgencia
                    select conta).FirstOrDefault()!;
        }
        catch (Exception ex)
        {
            throw new ByteBankExceptions(ex.Message);
        }

    }

    private ContaCorrente PesquisarContaPorCPF()
    {
        Console.Write("\nInforme o CPF: ");
        var cpf = Console.ReadLine();
        return listaDeContas.Find(x => x.Titular.Cpf.Equals(cpf))!;
    }

    private ContaCorrente PesquisarContaPorNumeroDaConta()
    {
        Console.Write("\nInforme o Número Da Conta: ");
        var numeroConta = Console.ReadLine()!;

        return (from conta in listaDeContas
                where conta.Conta == numeroConta
                select conta).FirstOrDefault()!;
    }

    private void OrdernarContas()
    {
        Console.Clear();
        Console.WriteLine("#######################");
        Console.WriteLine("### ORDERNAR CONTAS ###");
        Console.WriteLine("#######################\n");

        //Console.WriteLine("1 - Ordernar por Saldo");
        //Console.WriteLine("2 - Ordernar por Conta");
        //Console.WriteLine("3 - Ordernar por Agência");
        //Console.WriteLine("4 - Ordernar por Nome");
        //Console.Write("Digite a opção: ");
        //string tipoOrdenacao = Console.ReadLine()!;

        //switch (tipoOrdenacao)
        //{
        //    case "1":
        //        listaDeContas = listaDeContas.Sort();
        //        Console.WriteLine("\nOrdenção feita com sucesso!");
        //        break;
        //    case "2": 
        //        listaDeContas = listaDeContas.OrderBy(x => x.Conta).ToList();
        //        Console.WriteLine("\nOrdenção feita com sucesso!");
        //        break;
        //    case "3":
        //        listaDeContas = listaDeContas.OrderBy(x => x.Numero_agencia).ToList();
        //        Console.WriteLine("\nOrdenção feita com sucesso!");
        //        break;
        //    case "4":
        //        listaDeContas = listaDeContas.OrderBy(x => x.Titular.Nome).ToList();
        //        Console.WriteLine("\nOrdenção feita com sucesso!");
        //        break;
        //    default : 
        //        Console.WriteLine("\nOpção inválida."); 
        //        break;
        //}

        listaDeContas.Sort();

        Console.WriteLine("\nOrdenção feita com sucesso!");
        Console.ReadKey();
    }

    private void RemoveConta()
    {
        Console.Clear();
        Console.WriteLine("#####################");
        Console.WriteLine("### REMOVER CONTA ###");
        Console.WriteLine("#####################\n");

        Console.Write("Informe o número da conta: ");
        string numeroConta = Console.ReadLine()!;
        var contaRemove = listaDeContas.Find(x => x.Conta!.Equals(numeroConta));

        if (contaRemove != null)
        {
            listaDeContas.Remove(contaRemove);
            Console.WriteLine("Conta removida com sucesso!");
        }
        else
        {
            Console.WriteLine("Conta não encontrada.");
        }

        Console.WriteLine("\nPressione uma tecla para voltar ao menu.");
        Console.ReadKey();
    }

    private void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("#####################");
        Console.WriteLine("### LISTAR CONTAS ###");
        Console.WriteLine("#####################\n");

        if (listaDeContas.Count > 0)
        {
            foreach (var item in listaDeContas)
            {
                Console.WriteLine(item);
            }
        }
        Console.WriteLine("\nPressione uma tecla para voltar ao menu.");
        Console.ReadKey();
    }

    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("###########################");
        Console.WriteLine("### CADASTRO DE CONTAS  ###");
        Console.WriteLine("###########################\n");
        Console.WriteLine("### Informe dados da conta ###");
        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine()!);

        Console.Write("Informe o saldo inicial: ");
        double saldo = double.Parse(Console.ReadLine()!);

        ContaCorrente conta = new ContaCorrente(numeroAgencia, saldo);
        Console.WriteLine($"O Número da conta Nova é: {conta.Conta} ");

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine()!;

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine()!;

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine()!;

        listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }
}
