using System;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos.Models;

public class Operador
{
    private string _matricula;

    private string _nome;

    public string Matricula { get { return _matricula; } set { _matricula = value; } }

    public string Nome { get { return _nome; } set { _nome = value; } }

    public Operador()
    {
        Matricula = new Guid().ToString();
    }

    public override string ToString()
    {
        return $"Operador: {this.Nome}\n" +
               $"Matricula: {this.Matricula}\n";
    }
}
