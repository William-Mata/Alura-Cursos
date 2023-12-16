using Alura.Estacionamento.Alura.Estacionamento.Modelos.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos.Models;

public class Patio
{

    public Patio()
    {
        Faturado = 0;
        veiculos = new List<Veiculo>();
    }
    private List<Veiculo> veiculos;

    private double faturado;

    private Operador _operador;

    public Operador Operador { get => _operador; set => _operador = value; }

    public double Faturado { get => faturado; set => faturado = value; }

    public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

    public double TotalFaturado()
    {
        return Faturado;
    }

    public string MostrarFaturamento()
    {
        string totalfaturado = string.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", TotalFaturado());
        return totalfaturado;
    }

    public string RegistrarEntradaVeiculo(Veiculo veiculo)
    {
        veiculo.HoraEntrada = DateTime.Now;
        Veiculos.Add(veiculo);
        return GerarTicket(veiculo);
    }

    public string RegistrarSaidaVeiculo(string placa)
    {
        Veiculo procurado = null;
        string informacao = string.Empty;

        foreach (Veiculo v in Veiculos)
        {
            if (v.Placa == placa)
            {
                v.HoraSaida = DateTime.Now;
                TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                double valorASerCobrado = 0;
                if (v.Tipo == TipoVeiculo.Automovel)
                {
                    /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                    /// Ex.: 0,9999 ou 0,0001 teto = 1
                    /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                    valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;

                }
                if (v.Tipo == TipoVeiculo.Motocicleta)
                {
                    valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                }
                informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                         "Hora de saída: {1: HH:mm:ss}\n " +
                                         "Permanência: {2: HH:mm:ss} \n " +
                                         "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                procurado = v;
                Faturado = Faturado + valorASerCobrado;
                break;
            }

        }
        if (procurado != null)
        {
            Veiculos.Remove(procurado);
        }
        else
        {
            return "Não encontrado veículo com a placa informada.";
        }

        return informacao;
    }

    public string PesquisarVeiculoPatio(string idTicket)
    {
        var consulta = (from veiculo in Veiculos
                        where veiculo.IdTicket == idTicket
                        select veiculo.IdTicket).SingleOrDefault();

        return consulta;
    }

    public Veiculo AlterarDadosVeiculoPatio(Veiculo veiculoAlterado)
    {
        var carro = (from carroAltera in Veiculos
                     where carroAltera.Placa == veiculoAlterado.Placa
                     select carroAltera).SingleOrDefault();

        carro.AlterarVeiculo(veiculoAlterado);

        return carro;
    }

    private string GerarTicket(Veiculo veiculo)
    {
        veiculo.IdTicket = new Guid().ToString().Substring(0, 20);
        veiculo.Ticket = $"### Ticket Estacionamento Alura ###\n" +
                         $"Identificador: {veiculo.IdTicket}\n" +
                         $"Data/Hora de Entrada: {veiculo.HoraEntrada}\n" +
                         $"Placa do Veiculo: {veiculo.Placa}\n" +
                         $"Operador: {Operador.Nome}";

        return veiculo.Ticket;
    }
}
