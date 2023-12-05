using  bytebank_Modelos.bytebank.Modelos.ADM.Funcionarios;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_Modelos.bytebank.Modelos.Conta;
using bytebank_GeradorArquivo.bytebank.Util;
using bytebank_GeradorChavePix;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();



#region CHAMADA DAS DLL
Console.WriteLine(GeradorPix.GerarChavePix()); // USANDO O PACOTE NUGET PUBLICADO GeradorChavePixWilliamMata
var listaChaves = GeradorPix.GerarChavesPix(5);

// List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
//      new ContaCorrente(95, "123456-X"){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique"}},
//      new ContaCorrente(95, "951258-X"){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro"}},
//      new ContaCorrente(94, "987321-W"){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa"}}
//    };

//Arquivo<ContaCorrente>.GerarArquivoJSON(_listaDeContas);
//Arquivo<ContaCorrente>.GerarArquivoXML(_listaDeContas);
#endregion

#region EXEMPLO DE VISIBILDIADE INTERNAL
//public class Estagiario : Funcionario
//{
//    public double Salario { get; set; }
//    public string CPF { get; set; }

//    public Estagiario(double salario, string cpf) : base(salario, cpf)
//    {
//        Salario = salario;
//        CPF = cpf;
//    }

//    public override void AumentarSalario()
//    {
//        Salario *= 0.15;
//    }

//    // HERDANDO DA CLASS FUNCIONARIO QUE TEM UM MÉTODO COM VISIBILIDADE INTERNAL
//    protected override double getBonificacao()
//    {
//        return  Salario * 0.10;
//    }
//}
#endregion