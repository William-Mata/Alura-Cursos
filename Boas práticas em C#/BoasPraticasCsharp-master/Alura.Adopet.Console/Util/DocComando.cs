namespace Alura.Adopet.Console.Util;

[AttributeUsage(AttributeTargets.Class)]
public class DocComando : Attribute
{
    public string Instrucao { get; set; }
    public string Documentacao { get; set; }

    public DocComando(string instrucao, string documentacao)
    {
        Instrucao = instrucao;
        Documentacao = documentacao;
    }

}
