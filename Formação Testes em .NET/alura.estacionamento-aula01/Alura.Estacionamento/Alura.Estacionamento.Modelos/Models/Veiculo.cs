using Alura.Estacionamento.Alura.Estacionamento.Modelos.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos.Models;

public class Veiculo : IEnumerable<object[]>
{
    //Campos    
    private string _placa;
    private string _proprietario;
    private TipoVeiculo _tipo;

    //Propriedades   
    public string Placa
    {
        get
        {
            return _placa;
        }
        set
        {
            // Checa se o valor possui pelo menos 8 caracteres
            if (value.Length != 8)
            {
                throw new FormatException(" A placa deve possuir 8 caracteres");
            }
            for (int i = 0; i < 3; i++)
            {
                //checa se os 3 primeiros caracteres são numeros
                if (char.IsDigit(value[i]))
                {
                    throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                }
            }
            //checa o Hifem
            if (value[3] != '-')
            {
                throw new FormatException("O 4° caractere deve ser um hífen");
            }
            //checa se os 3 primeiros caracteres são numeros
            for (int i = 4; i < 8; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                }
            }
            _placa = value;

        }
    }
    /// <summary>
    /// { get; set; } cria uma propriedade automática, ou seja,
    /// durante a compilação, é gerado um atributo para armazenar
    /// o valor da propriedade e os metodos get e set, respectivamente,
    /// lêem e escrevem diretamente no atributo gerado, sem
    /// qualquer validação. É um recurso útil, pois as propriedades
    /// permitem fazer melhor uso do recurso de Reflection do .Net
    /// Framework, entre outros benefícios.
    /// </summary>
    public string Cor { get; set; }
    public double Largura { get; set; }
    public double VelocidadeAtual { get; set; }
    public string Modelo { get; set; }
    public string Proprietario
    {
        get
        {
            return _proprietario;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new FormatException("Nome do proprietario é inválido.");
            }
            _proprietario = value;
        }
    }
    public DateTime HoraEntrada { get; set; }
    public DateTime HoraSaida { get; set; }
    public TipoVeiculo Tipo
    {
        get { return _tipo; }
        set
        {
            if (value == null)
            {
                _tipo = TipoVeiculo.Automovel;
            }
            else { _tipo = value; }
        }
    }
    public string IdTicket { get; internal set; }
    public string Ticket { get; internal set; }

    //Métodos
    public void Acelerar(int tempoSeg)
    {
        VelocidadeAtual += tempoSeg * 10;
    }

    public void Frear(int tempoSeg)
    {
        VelocidadeAtual -= tempoSeg * 15;
    }

    public void AlterarVeiculo(Veiculo veiculoAlterado)
    {
        Proprietario = veiculoAlterado.Proprietario;
        Cor = veiculoAlterado.Cor;
        Modelo = veiculoAlterado.Modelo;
        Placa = veiculoAlterado.Placa;
    }

    public override string ToString()
    {
        return $"Tipo do Veiculo: {Tipo}\n" +
               $"Cor: {Cor}\n" +
               $"Modelo: {Modelo}\n" +
               $"Placa: {Placa}";
    }


    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Veiculo
            {
                Proprietario = "William",
                Placa = "ADS-2018",
                Cor = "Preto",
                Modelo = "Honda Civic"
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    //Construtor
    public Veiculo()
    {

    }

    public Veiculo(string proprietario)
    {
        Proprietario = proprietario;
    }
}
