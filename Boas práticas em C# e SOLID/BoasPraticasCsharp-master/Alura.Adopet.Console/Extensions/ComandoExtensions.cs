using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions;

public static class ComandoExtensions
{
    public static Type? GetTipoComando(this Assembly assembly, string instrucao)
    {
        return assembly.GetTypes() // lista todos os tipos
               .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando))) // filtra apenas as classes que implementam a interface IComando
               .FirstOrDefault(t => t.GetCustomAttributes<DocComando>().Any(d => d.Instrucao.Equals(instrucao))); // pega o primeiro comando que contém a instrução passada
    }


    public static IEnumerable<IFabricaComando> GetComandos(this Assembly assembly)
    {
        return assembly.GetTypes() // lista todos os tipos
               .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IFabricaComando))) // filtra apenas as classes que implementam a interface IComando
               .Select(c => Activator.CreateInstance(c) as IFabricaComando).ToList()!; // pega o primeiro comando que contém a instrução passada
    }
}