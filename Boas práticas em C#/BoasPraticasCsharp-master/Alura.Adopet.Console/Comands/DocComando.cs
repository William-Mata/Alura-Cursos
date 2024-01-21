﻿namespace Alura.Adopet.Console.Comands;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DocComando : Attribute
{
    public string Instrucao { get; set; }
    public string Documentacao { get; set; }

    public DocComando(string instrucao, string documentacao)
    {
        Instrucao = instrucao;
        Documentacao = documentacao;
    }

}
