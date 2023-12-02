using Loja.Models;
using Services;
using System;
using Utils;

namespace Models;

public class Produto
{
    public string? Nome { get; set; }
    public int Quantidade { get; set; }
    public string? Tipo { get; set; }
    public decimal Valor { get; set; }
    public string Beneficio { get; }
    public int QuantidadeVendida { get; set; }

    public Produto(string nome, int quantidade, string? tipo)
    {
        Nome = nome;
        Quantidade = quantidade;
        Tipo = tipo;
        Beneficio = ChatGPT.PerguntarChatGPT($"Qual o beneficio o produto {Nome} fornece, resuma em 2 linhas no máximo.").Result;
    }

    public override string ToString()
    {
        return $"\nNome: {Nome}\n" +
               $"Tipo: {Tipo}\n" +
               $"Quantidade: {Quantidade}\n" +
               $"Valor: {Valor}\n" +
               $"Beneficio: {Beneficio}\n";
    }

    public static Produto CadastrarProduto()
    {
        Console.Clear();
        Console.WriteLine("########## CADASTRO DE PRODUTO ##########");

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine()!;
        Console.Write("Digite o tipo do produto: ");
        string tipo = Console.ReadLine()!;
        Console.Write("Digite a quantidade desse produto: ");
        var quantidade = int.Parse(Console.ReadLine()!);
        Console.Write("Digite o valor do produto: ");
        decimal valor = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine($"Aguarde produto está sendo cadastrado...");
        Produto produto = new Produto(nome, quantidade, tipo);
        produto.Valor = valor;

        Console.WriteLine("\nProduto cadastrado com sucesso!");
        Menu.VoltarAoMenu();
        return produto;
    }

    public static void ListarProdutos(List<Produto> produtos)
    {
        Console.Clear();
        Console.WriteLine("########## LISTA DE PRODUTOS ##########");
        produtos.ForEach(Console.WriteLine);
        Menu.VoltarAoMenu();
    }

    public static void ConsultarProduto(List<Produto> produtos)
    {
        Console.Clear();
        Console.WriteLine("########## CONSULTAR PRODUTO ##########");

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine()!;

        var produto = produtos.FirstOrDefault(x => x.Nome!.Equals(nome));
        if (produto != null)
        {
            Console.WriteLine("\nProduto encontrado: ");
            Console.WriteLine(produto);
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.");
        }

        Menu.VoltarAoMenu();
    }

    public static void VenderProduto(List<Produto> produtos)
    {
        Console.Clear();
        Console.WriteLine("########## CONSULTAR PRODUTO ##########");

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine()!;

        var produto = produtos.FirstOrDefault(x => x.Nome!.Equals(nome));
        if (produto != null)
        {
            Console.Write("Digite a quantidade do produto: ");
            int quantidade = int.Parse(Console.ReadLine()!);

            if (quantidade > 0 && produto.Quantidade >= quantidade)
            {
                produto.Quantidade -= quantidade;
                produto.QuantidadeVendida += quantidade;
                var valorVenda = produto.Valor * quantidade;
                Caixa.Valor = valorVenda;
                Console.WriteLine($"Venda no valor de {valorVenda.ToString("C")} realizada com sucesso.");
            }
            else
            {
                Console.WriteLine("\nQuantidade indisponivel");
            }
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.");
        }

        Menu.VoltarAoMenu();
    }

    public static void RemoverProduto(List<Produto> produtos)
    {
        Console.Clear();
        Console.WriteLine("########## REMOVER PRODUTO ##########");

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine()!;

        var produtoRemover = produtos.FirstOrDefault(x => x.Nome!.Equals(nome));
        if(produtoRemover != null )
        {
            Console.WriteLine("\nProduto encontrado: ");
            Console.WriteLine(produtoRemover);
            Console.Write("Deseja realmente remover o produto digite S ou N: ");
            var confirmacao = Console.ReadLine()!;  
           
            if(confirmacao == "S")
            {
                produtos.Remove(produtoRemover);
                Console.WriteLine("Produto removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.");
        }

        Menu.VoltarAoMenu();
    }

    internal static void AlterarProduto(List<Produto> produtos)
    {
        Console.Clear();
        Console.WriteLine("########## ALTERAR PRODUTO ##########");

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine()!;

        var produtoAlterar = produtos.FirstOrDefault(x => x.Nome!.Equals(nome));
        if (produtoAlterar != null)
        {
            Console.WriteLine("\nProduto encontrado: ");
            Console.WriteLine(produtoAlterar);

            Console.Write("##################################\n");
            Console.Write("Digite o novo nome do produto: ");
            produtoAlterar.Nome = Console.ReadLine()!;
            Console.Write("Digite o novo tipo do produto: ");
            produtoAlterar.Tipo = Console.ReadLine()!;
            Console.Write("Digite a nova quantidade desse produto: ");
            produtoAlterar.Quantidade = int.Parse(Console.ReadLine()!);
            Console.Write("Digite o novo valor do produto: ");
            produtoAlterar.Valor = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine("\nProduto alterado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.");
        }

        Menu.VoltarAoMenu();
    }
}
